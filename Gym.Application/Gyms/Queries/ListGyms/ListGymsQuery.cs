using ErrorOr;
using MediatR;
using GymManagement.Domain.Gyms;
using System;
using System.Collections.Generic;

namespace GymManagement.Application.Gyms.Queries.ListGyms;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;