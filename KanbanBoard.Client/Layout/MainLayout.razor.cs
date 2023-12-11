using Microsoft.AspNetCore.Components.Web;

namespace KanbanBoard.Client.Layout;

public partial class MainLayout
{
    private ErrorBoundary _errorBoundary;

    protected override void OnParametersSet()
    {
        _errorBoundary?.Recover();
    }
}
