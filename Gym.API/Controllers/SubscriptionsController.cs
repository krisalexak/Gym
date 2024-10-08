using Gym.Application.Services;
using Gym.Application.Subscriptions.Commands;
using Gym.Application.Subscriptions.Queries;
using Gym.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISender _mediator;
        public SubscriptionsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
        {
            var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.SubscriptionId);
            var createSubscriptionResult = await _mediator.Send(command);

            return createSubscriptionResult.MatchFirst(
                subscription => Ok(new CreateSubscriptionResponse(subscription.Id, request.SubscriptionType)),
                error => Problem()
                );
        }
        [HttpGet("{subscriptionId:guid}")]
        public async Task<IActionResult> GetSubscription(Guid subscriptionId)
        {
            var query = new GetSubscriptionQuery(subscriptionId);

            var getSubscriptionsResult = await _mediator.Send(query);

            return getSubscriptionsResult.MatchFirst(
                subscription => Ok(new SubscriptionResponse(subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
                error => Problem(error.Description,error.Code)
                );

        }
    }
}
