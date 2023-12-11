using KanbanBoard.Domain.Repositories;
using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;
using MediatR;

namespace KanbanBoard.Application.Items.Commands.Handlers;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public AddItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var itemToAdd = Domain.Entities.Item.Create(request.Description, State.New);
        await _itemRepository.AddAsync(itemToAdd);
    }
}