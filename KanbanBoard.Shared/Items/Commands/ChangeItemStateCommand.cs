using KanbanBoard.Shared.Models;
using MediatR;
using System;

namespace KanbanBoard.Shared.Items.Commands;

public sealed record ChangeItemStateCommand(Guid Id, State State) : IRequest;
