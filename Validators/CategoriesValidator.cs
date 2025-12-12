using FluentValidation;
using Models.Dtos;

public class CategoriesDtoValidator : AbstractValidator<CategoriesRequest>
{
    public CategoriesDtoValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .Length(3, 100).WithMessage("Debe tener entre 3 y 100 caracteres");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("La descripción es obligatoria")
            .Length(5, 100).WithMessage("Debe tener entre 5 y 100 caracteres");
    }
}
