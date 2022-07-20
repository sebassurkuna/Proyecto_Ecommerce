using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class MetodoEntregaValidation : AbstractValidator<AgregarMetodoEntregaDto>
    {
        public MetodoEntregaValidation()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(20)
                .NotEmpty().WithMessage("El campo Nombre es requerido")
                .NotNull().
                Matches(@"^[A-Za-z\s]+$").WithMessage("Solo se acepta letras"); ;

            RuleFor(x => x.Descripcion)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Descripcion es requerido")
                .NotNull().
                Matches(@"^[A-Za-z0-9\s]+$").WithMessage("Solo se acepta letras y números"); 

            RuleFor(x => x.CostoEntrega)
                .NotNull()
                .NotEmpty().WithMessage("El campo Costo de Entrega es requerido");
        }
    }
}
