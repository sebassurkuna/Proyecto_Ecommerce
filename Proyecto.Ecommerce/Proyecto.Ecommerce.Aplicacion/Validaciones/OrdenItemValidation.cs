using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class OrdenItemValidation : AbstractValidator<AgregarOrdenItemsDto>
    {
        public OrdenItemValidation()
        {
            RuleFor(x => x.ProductoId)
                .NotNull()
                .NotEmpty().WithMessage("El campo ProductoId es requerido"); 

            RuleFor(x => x.CantidadProducto)
                .NotNull()
                .NotEmpty().WithMessage("El campo Cantidad de Producto es requerido");
        }
    }
}
