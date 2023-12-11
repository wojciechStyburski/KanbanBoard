using System;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Models;

public class Item
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Pole 'Opis' jest wymagane.")] public string Description { get; set; }
    public State State { get; set; }
}