using KanbanBoard.Client.HttpStorage.Items;
using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Pages;

public partial class Archive
{
    private List<Item> _items;
    [Inject] public IItemStorage ItemStorage { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await Refresh();
    }

    private async Task RestoreTask(Guid id)
    {
        var command = new ChangeItemStateCommand(id, State.Active);
        await ItemStorage.ChangeItemState(command);
     
        await Refresh();
    }

    private async Task Refresh()
    {
        _items = (List<Item>) await ItemStorage.GetArchive();
    }
}
