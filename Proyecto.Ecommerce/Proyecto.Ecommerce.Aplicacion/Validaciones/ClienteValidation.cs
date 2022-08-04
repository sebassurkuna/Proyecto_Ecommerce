using FluentValidation;
using Proyecto.Ecommerce.Aplicacion.Dtos;

namespace Proyecto.Ecommerce.Aplicacion.Validaciones
{
    public class ClienteValidation : AbstractValidator<ClienteDto>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Nombre)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Nombre es requerido")
                .NotNull().
                Matches("^[A-Za-z]+$").WithMessage("Solo se acepta letras");

            RuleFor(x => x.Apellido)
                .MaximumLength(256)
                .NotEmpty().WithMessage("El campo Apellido es requerido")
                .NotNull().
                Matches("^[A-Za-z]+$").WithMessage("Solo se acepta letras");

            RuleFor(x => x.Contraseña)
                .MaximumLength(20)
                .NotEmpty().WithMessage("El campo Contraseña es requerido")
                .NotNull().
                Matches("^[A-Za-z0-9]+$").WithMessage("Solo se acepta letras y numeros");

            RuleFor(x => x.NombreUsuario)
                .MaximumLength(50)
                .NotEmpty().WithMessage("El campo Nombre de Usuario es requerido")
                .NotNull().
                Matches("^[A-Za-z0-9]+$").WithMessage("Solo se acepta letras y numeros");

            RuleFor(x => x.Edad)
                .NotNull()
                .NotEmpty().WithMessage("El campo Edad es requerido")
                .ExclusiveBetween(17,71).WithMessage("Solo se aceptan clientes con edades entre 18 y 70");

            RuleFor(x => x.NumeroCedula)
                .NotNull()
                .NotEmpty().WithMessage("El campo Numero de Cedula es requerido")
                .Length(10).WithMessage("Cantidad de digitos incorrecto")
                .Matches("^[0-9]+$").WithMessage("Solo se aceptan números");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El campo Email es requerido")
                .NotNull()
                .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+$")
                .WithMessage("Email incorrecto");
        }
    }
}
