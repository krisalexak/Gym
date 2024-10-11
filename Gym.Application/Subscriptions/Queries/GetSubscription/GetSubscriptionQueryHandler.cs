using ErrorOr;
using Gym.Application.Common.Interfaces;
using Gym.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gym.Application.Subscriptions.Queries
{
    public record GetSubscriptionQueryHandler : IRequestHandler<GetSubscriptionQuery, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        // private readonly IUnitOfWork _unitOfWork;
        public GetSubscriptionQueryHandler(ISubscriptionRepository subscriptionRepository/*,IUnitOfWork unitOfWork*/)
        {
            _subscriptionRepository = subscriptionRepository;
            // _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<Subscription>> Handle(GetSubscriptionQuery query, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(query.SubscriptionId);

            //await _unitOfWork.CommitChangesAsync();
            return subscription is null ? Error.NotFound(description: "Not Found") : subscription;
        }
    }
}
