using KanbanBoard.Domain.Entities;
using KanbanBoard.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Infrastructure.DAL.Repositories;

public sealed class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Item item)
    {
        await _dbContext.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Item item)
    {
        _dbContext.Update(item);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Item item)
    {
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
        => _dbContext.Items.ToList();

    public async Task<Item> GetByIdAsync(Guid id)
        => await _dbContext.Items.SingleOrDefaultAsync(x => x.Id == id);

    
}