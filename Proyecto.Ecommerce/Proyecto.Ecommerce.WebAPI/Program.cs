using Proyecto.Ecommerce.Aplicacion.ImplServicios;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using Proyecto.Ecommerce.Dominio.Repositorio;
using Proyecto.Ecommerce.Infraestructura.Context;
using Proyecto.Ecommerce.Infraestructura.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Agregar context
builder.Services.AddDbContext<EcommerceDbContext>();

//Agregar dependencias
builder.Services.AddTransient<IClienteAppServicio, ClienteAppServicio>();
builder.Services.AddTransient<IMarcaAppServicio, MarcaAppServicio>();
builder.Services.AddTransient<IMetodoEntregaAppServicio, MetodoEntregaAppServicio>();
builder.Services.AddTransient<IOrdenAppServicio, OrdenAppServicio>();
builder.Services.AddTransient<IOrdenItemsAppServicio, OrdenItemsAppServicio>();
builder.Services.AddTransient<IProductoAppServicio, ProductoAppServicio>();
builder.Services.AddTransient<ITipoProductoAppServicio, TipoProductoAppServicio>();

builder.Services.AddTransient(typeof(IRepositorioGenerico<>),typeof(RepositorioGenerico<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
