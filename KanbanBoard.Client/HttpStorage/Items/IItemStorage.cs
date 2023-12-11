using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;

namespace KanbanBoard.Client.HttpStorage.Items;

public interface IItemStorage
{
    Task Add(AddItemCommand commad);
    Task ChangeItemState(ChangeItemStateCommand command);
    Task<IEnumerable<Item>> GetAll();
    Task<IEnumerable<Item>> GetArchive();
}
