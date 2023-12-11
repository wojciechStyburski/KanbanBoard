using KanbanBoard.Shared.Models;
using MediatR;

namespace KanbanBoard.Shared.Items.Commands;

public sealed record AddItemCommand(string Description) : IRequest;
