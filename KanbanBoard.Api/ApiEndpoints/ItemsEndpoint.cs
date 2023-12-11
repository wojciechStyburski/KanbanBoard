using KanbanBoard.Shared.Items.Commands;
using KanbanBoard.Shared.Items.Queries;
using MediatR;

namespace KanbanBoard.Api.ApiEndpoints;

internal static class ItemsEndpoint
{
    private const string API_ROUTE = "/api/items";
    public static WebApplication UseItemsEndpoint(this WebApplication app)
    {
        app.MapGet(API_ROUTE, async (IMediator mediator) =>
        {
            var items = await mediator.Send(new GetItemsQuery());
            return Results.Ok(items);
        });

        app.MapGet($"{API_ROUTE}-archive", async (IMediator mediator) =>
        {
            var items = await mediator.Send(new GetArchiveItemsQuery());
            return Results.Ok(items);
        });

        app.MapPost(API_ROUTE, async (IMediator mediator, AddItemCommand command) =>
        {
            await mediator.Send(command);
            return Results.Created();
        });

        app.MapPut(API_ROUTE, async (IMediator mediator, ChangeItemStateCommand command) =>
        {
            await mediator.Send(command);
            return Results.NoContent();
        });

        return app;
    }
}