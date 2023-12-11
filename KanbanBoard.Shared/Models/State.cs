using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Models;

public enum State
{

    [Display (Name = "Nowy")] New,
    [Display(Name = "Aktywny")] Active,
    [Display(Name = "Zakończony")] Closed,
    [Display(Name = "Zarchiwizowany")] Archive
}