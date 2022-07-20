using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class ProductoValidation : AbstractValidator<AgregarProductoDto>
    {
        public ProductoValidation()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Nombre es requerido")
                .NotNull().
                Matches(@"^[A-Za-z\s]+$").WithMessage("Solo se acepta letras"); ;

            RuleFor(x => x.Descripcion)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Descripcion es requerido")
                .NotNull().
                Matches(@"^[A-Za-z0-9\s]+$").WithMessage("Solo se acepta letras y números");

            RuleFor(x => x.Precio)
                .NotNull()
                .NotEmpty().WithMessage("El campo Precio es requerido"); ;

            RuleFor(x => x.Stock)
                .NotNull()
                .NotEmpty().WithMessage("El campo Stock es requerido"); ;

            RuleFor(x => x.MarcaId)
                .NotNull()
                .NotEmpty().WithMessage("El campo MarcaId es requerido")
                .Length(4).WithMessage("Id de la Marca es incorrecto");

            RuleFor(x => x.TipoProductoId)
                .NotNull()
                .NotEmpty().WithMessage("El campo TipoProductoId es requerido")
                .Length(4).WithMessage("Id del Tipo de Producto es incorrecto"); ;
        }
    }
}
