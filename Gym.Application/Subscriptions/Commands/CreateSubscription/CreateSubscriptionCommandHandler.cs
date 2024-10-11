using ErrorOr;
using Gym.Application.Common.Interfaces;
using Gym.Application.Subscriptions.Queries;
using Gym.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gym.Application.Subscriptions.Commands
{
    public record GetSubscriptionQueryHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetSubscriptionQueryHandler(
            ISubscriptionRepository subscriptionRepository, 
            IUnitOfWork unitOfWork) 
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = new Subscription() 
            {
                Id = Guid.NewGuid(),
                SubscriptionType = request.SubscriptionType
            };
            await _subscriptionRepository.AddSubscriptionAsync(subscription);
            await _unitOfWork.CommitChangesAsync();

            return subscription;
        }
    }
}
