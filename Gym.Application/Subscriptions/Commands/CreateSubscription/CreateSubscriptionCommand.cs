using ErrorOr;
using Gym.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.Subscriptions.Commands
{
    public record CreateSubscriptionCommand(SubscriptionType SubscriptionType,Guid SubscriptionId, Guid AdminId) :IRequest<ErrorOr<Subscription>>;
}
