using Proyecto.Ecommerce.Aplicacion.InyeccionDependencias;
using Proyecto.Ecommerce.Dominio.InyeccionDependencias;
using Proyecto.Ecommerce.Infraestructura.Context;
using Proyecto.Ecommerce.Infraestructura.InyeccionDependencias;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Agregar context
builder.Services.AddDbContext<EcommerceDbContext>();

//Agregar dependencias
builder.Services.AddApp(builder.Configuration);
builder.Services.AddDominio(builder.Configuration);
builder.Services.AddInfraestructura(builder.Configuration);


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
