using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class TipoProductoValidation : AbstractValidator<AgregarTipoProductoDto>
    {
        public TipoProductoValidation()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(20)
                .NotEmpty().WithMessage("El campo Nombre es requerido")
                .NotNull().
                Matches(@"^[A-Za-z\s]+$").WithMessage("Solo se acepta letras"); ;
        }
    }
}
