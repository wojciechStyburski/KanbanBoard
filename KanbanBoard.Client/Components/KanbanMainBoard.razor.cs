using KanbanBoard.Client.HttpStorage.Items;
using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Components;

public partial class KanbanMainBoard
{
    private List<Item> _items;
    private Item _currentItem;
    private string _dialogBody;
    private Guid _archiveItemId;
    private Item _newItem = new();

    [Inject] public IItemStorage ItemStorage { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Refresh();
    }

    private async Task OnDrop(State state)
    {
        _currentItem.State = state;

        var command = new ChangeItemStateCommand(_currentItem.Id, _currentItem.State);
        await ItemStorage.ChangeItemState(command);
    }

    private void OnStartDrag(Item item)
    {
        _currentItem = item;
    }

    private async Task OnArchive(Item item)
    {
        var command = new ChangeItemStateCommand(item.Id, State.Archive);
        await ItemStorage.ChangeItemState(command);

        await Refresh();
    }

    private async Task Refresh()
    {
        _items = (List<Item>)await ItemStorage.GetAll();
    }

    private async Task Save()
    {
        _newItem.State = State.New;

        var command = new AddItemCommand(_newItem.Description);
        await ItemStorage.Add(command);
        
        await Refresh();
        _newItem = new();
    }
}