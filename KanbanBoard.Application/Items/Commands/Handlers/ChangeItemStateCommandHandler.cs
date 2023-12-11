using KanbanBoard.Application.Exceptions;
using KanbanBoard.Domain.Repositories;
using KanbanBoard.Shared.Items.Commands;
using MediatR;

namespace KanbanBoard.Application.Items.Commands.Handlers;

public class ChangeItemStateCommandHandler : IRequestHandler<ChangeItemStateCommand>
{
    private readonly IItemRepository _itemRepository;

    public ChangeItemStateCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task Handle(ChangeItemStateCommand request, CancellationToken cancellationToken)
    {
        var itemToChange = await _itemRepository.GetByIdAsync(request.Id) ?? throw new ItemNotFoundException(request.Id);
        itemToChange.ChangeState(request.State);
        await _itemRepository.UpdateAsync(itemToChange);
    }
}