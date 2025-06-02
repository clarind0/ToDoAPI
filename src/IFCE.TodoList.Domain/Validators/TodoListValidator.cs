using FluentValidation;
using IFCE.TodoList.Domain.Entities;

namespace IFCE.TodoList.Domain.Validators;

public class TodoListValidator : AbstractValidator<TodoList.Domain.Entities.TodoList>
{
    public TodoListValidator()
    { 
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id vazio ou nulo");
        
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome vazio ou nulo")
            
            .MinimumLength(3)
            .WithMessage("O nome dever ter no mínimo 3 caracteres")
            
            .MaximumLength(50)
            .WithMessage("O nome deve ter no máximo 50 caracteres");
        
        RuleFor(x => x.Deadline)
            .GreaterThan(DateTime.Now)
            .WithMessage("Informe uma data maior do que o momento presente");
    }
    
}