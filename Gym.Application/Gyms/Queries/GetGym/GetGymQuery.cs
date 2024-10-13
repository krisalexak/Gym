using ErrorOr;
using GymManagement.Domain.Gyms;
using MediatR;
using System;

namespace GymManagement.Application.Gyms.Queries.GetGym;

public record GetGymQuery(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Gym>>;