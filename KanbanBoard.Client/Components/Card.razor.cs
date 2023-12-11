using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Components;

public partial class Card
{
    [Parameter] public string Classes { get; set; }
    [Parameter] public string Title { get; set; }
    [Parameter] public RenderFragment Content { get; set; }
}
