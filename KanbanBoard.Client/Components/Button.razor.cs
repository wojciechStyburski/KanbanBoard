using Microsoft.AspNetCore.Components;

namespace KanbanBoard.Client.Components;

public partial class Button
{
    [Parameter] public string Classes { get; set; }
    [Parameter] public string Content { get; set; }
    
}
