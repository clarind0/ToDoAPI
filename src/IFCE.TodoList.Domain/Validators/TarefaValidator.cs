namespace IFCE.TodoList.Domain.Validators;
using FluentValidation;
using IFCE.TodoList.Domain.Entities;

public class TarefaValidator : AbstractValidator<Tarefa>
{
    public TarefaValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("A descrição não pode estar vazia")

            .NotNull()
            .WithMessage("A descrição não pode ser nula.")

            .MinimumLength(5)
            .WithMessage("A descrição deve conter no mínimo 5 caracteres.")

            .MaximumLength(100)
            .WithMessage("A descrição deve ter no máximo 100 caracteres");
        
        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("O Id do usuário não pode ser nulo.")

            .NotEmpty()
            .WithMessage("O Id do usuário não pode ser vazio.");
        
        RuleFor(x => x.Concluded)
            .NotEmpty()
            .WithMessage("O campo Concluded não pode estar vazio.")
            
            .NotNull()
            .WithMessage("O campo Concluded não pode ser nulo");

        RuleFor(x => x.Deadline)
            .GreaterThan(DateTime.Now)
            .WithMessage("Informe uma data maior do que o momento presente");
    }
}