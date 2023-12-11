using KanbanBoard.Shared.Models;

namespace KanbanBoard.Domain.Entities;

public class Item
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public State State { get; private set; }

    public static Item Create(string description, State state)
    {
        return new Item()
        {
            Id = Guid.NewGuid(),
            Description = description,
            State = state
        };
    }

    public void ChangeState(State state)
        => State = state;
}