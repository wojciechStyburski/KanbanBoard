using FluentValidation;

namespace KanbanBoard.Shared.Items.Commands.Validators;

public class ChangeItemStateCommandValidator : AbstractValidator<ChangeItemStateCommand>
{
    public ChangeItemStateCommandValidator()
    {
        RuleFor(x => x.State).NotEmpty();
    }
}