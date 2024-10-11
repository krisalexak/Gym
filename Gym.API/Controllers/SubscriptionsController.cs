using Gym.Application.Subscriptions.Commands;
using Gym.Application.Subscriptions.Queries;
using Gym.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = Gym.Domain.Subscriptions.SubscriptionType;

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
            if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest, 
                    detail: "Invalid subscription type");
            }
            var command = new CreateSubscriptionCommand(subscriptionType, request.SubscriptionId, request.AdminId);
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
                subscription => Ok(new SubscriptionResponse(subscription.Id, Enum.Parse<SubscriptionType>(subscription.SubscriptionType.Name))),
                error => Problem(error.Description, error.Code)
                );

        }
    }
}
