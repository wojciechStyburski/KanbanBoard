using KanbanBoard.Shared.Items.Queries;
using KanbanBoard.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Infrastructure.DAL.Items.Queries.Handlers;

public class GetArchiveItemsQueryHandler : IRequestHandler<GetArchiveItemsQuery, IEnumerable<Item>>
{
    private readonly ApplicationDbContext _dbContext;
    public GetArchiveItemsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Item>> Handle(GetArchiveItemsQuery request, CancellationToken cancellationToken)
            => await _dbContext
            .Items
            .Where(x => x.State == State.Archive)
            .AsNoTracking()
            .Select(x => new Item()
            {
                Id = x.Id,
                Description = x.Description,
                State = x.State
            })
            .ToListAsync(cancellationToken);
}
