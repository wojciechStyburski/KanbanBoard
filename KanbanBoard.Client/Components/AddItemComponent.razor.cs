using KanbanBoard.Client.HttpStorage.Items;
using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Components;

public partial class AddItemComponent
{
    private Item _newItem = new();
    [Inject] public IItemStorage ItemStorage { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private async Task Save()
    {
        _newItem.State = State.New;

        var command = new AddItemCommand(_newItem.Description);
        await ItemStorage.Add(command);

        _newItem = new();

        NavigationManager.Refresh();
    }
}
