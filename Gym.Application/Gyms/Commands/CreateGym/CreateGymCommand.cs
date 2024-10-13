using ErrorOr;
using GymManagement.Domain.Gyms;
using MediatR;
using System;

namespace GymManagement.Application.Gyms.Commands.CreateGym;

public record CreateGymCommand(string Name, Guid SubscriptionId) : IRequest<ErrorOr<Gym>>;