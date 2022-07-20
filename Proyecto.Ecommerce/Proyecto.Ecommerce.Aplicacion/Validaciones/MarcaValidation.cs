using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class MarcaValidation : AbstractValidator<AgregarMarcaDto>
    {
        public MarcaValidation()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Nombre es requerido")
                .NotNull().
                Matches(@"^[A-Za-z\s]+$").WithMessage("Solo se acepta letras"); ;
        }
    }
}
