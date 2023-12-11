using KanbanBoard.Domain.Exceptions;

namespace KanbanBoard.Application.Exceptions;

public class ItemNotFoundException : CustomException
{
    public Guid ItemId { get; set; }
    public ItemNotFoundException(Guid id) : base($"Item with id {id} was not found.")
    {
        ItemId = id;
    }
}