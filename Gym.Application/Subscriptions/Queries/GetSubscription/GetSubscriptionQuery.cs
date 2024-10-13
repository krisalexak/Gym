using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;
using System;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public record GetSubscriptionQuery(Guid SubscriptionId)
    : IRequest<ErrorOr<Subscription>>;