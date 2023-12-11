using FluentValidation;

namespace KanbanBoard.Shared.Items.Commands.Validators;

public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
{
    public AddItemCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(150);
    }
}