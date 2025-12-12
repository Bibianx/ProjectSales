using FluentValidation;
using Models.Dtos;

public class ProductDtoValidator : AbstractValidator<ProductsRequest>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .Length(3, 100).WithMessage("Debe tener entre 3 y 100 caracteres");

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("La unidad es obligatoria");
        
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("El precio es obligatorio")
            .GreaterThan(0).WithMessage("Valor debe ser mayor a 0");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("La categoría es obligatoria");
        
        RuleFor(x => x.SupplierId)
            .NotEmpty().WithMessage("El proveedor es obligatorio");
    }
}
