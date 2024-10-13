using ErrorOr;

using MediatR;
using System;

namespace GymManagement.Application.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(Guid GymId, Guid RoomId)
    : IRequest<ErrorOr<Deleted>>;