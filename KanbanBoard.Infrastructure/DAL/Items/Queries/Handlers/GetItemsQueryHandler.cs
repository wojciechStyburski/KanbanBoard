using KanbanBoard.Shared.Items.Queries;
using KanbanBoard.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Infrastructure.DAL.Items.Queries.Handlers;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<Item>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetItemsQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Item>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        => await _dbContext
            .Items
            .AsNoTracking()
            .Select(x => new Item()
            {
                Id = x.Id,
                Description = x.Description,
                State = x.State
            })
            .ToListAsync(cancellationToken); 
}