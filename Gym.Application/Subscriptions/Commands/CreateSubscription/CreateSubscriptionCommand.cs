using ErrorOr;
using GymManagement.Domain.Subscriptions;
using MediatR;
using System;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand(
    SubscriptionType SubscriptionType,
    Guid AdminId) : IRequest<ErrorOr<Subscription>>;