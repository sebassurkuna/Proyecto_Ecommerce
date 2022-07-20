using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class OrdenValidation : AbstractValidator<AgregarOrdenDto>
    {
        public OrdenValidation()
        {
            RuleFor(x => x.ClienteId)
                .NotNull()
                .NotEmpty().WithMessage("El campo ClienteId es requerido");

            RuleFor(x => x.MetodoEntregaId)
                .NotNull()
                .NotEmpty().WithMessage("El campo MetodoEntregaId es requerido")
                .Length(4).WithMessage("Id de Metodo en Entrega incorrecto");
        }
    }
}
