using KanbanBoard.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Components;

public partial class KanbanItem
{
    private string _classes = "";
    [Parameter] public State State { get; set; }
    [Parameter] public List<Item> Items { get; set; }
    [Parameter] public EventCallback<State> OnDrop { get; set; }
    [Parameter] public EventCallback<Item> OnStartDrag { get; set; }
    [Parameter] public EventCallback<Item> OnArchive { get; set; }

    protected override void OnInitialized()
    {
        switch(State)
        {
            case State.New:
                _classes = "btn-info";
                break;
            case State.Active:
                _classes = "btn-primary";
                break;
            case State.Closed:
                _classes = "btn-success";
                break;
            default:
                break;
        }
    }

    private void OnDropHandler() { OnDrop.InvokeAsync(State); }
    private void OnStartDragHandler(Item item) { OnStartDrag.InvokeAsync(item); }
    private void OnArchiveHandler(Item item) {  OnArchive.InvokeAsync(item); }
}
