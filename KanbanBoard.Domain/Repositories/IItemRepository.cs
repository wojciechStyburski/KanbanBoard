using KanbanBoard.Domain.Entities;

namespace KanbanBoard.Domain.Repositories;

public interface IItemRepository
{
    Task<Item> GetByIdAsync(Guid id);
    Task<IEnumerable<Item>> GetAllAsync();
    Task AddAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(Item item);
}