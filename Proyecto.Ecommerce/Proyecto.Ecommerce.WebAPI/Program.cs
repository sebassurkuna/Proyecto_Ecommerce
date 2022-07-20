using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Ecommerce.Aplicacion.InyeccionDependencias;
using Proyecto.Ecommerce.Dominio.InyeccionDependencias;
using Proyecto.Ecommerce.Infraestructura.InyeccionDependencias;
using Proyecto.Ecommerce.WebAPI.Controllers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//Agregar dependencias
builder.Services.AddApp(builder.Configuration);
builder.Services.AddDominio(builder.Configuration);
builder.Services.AddInfraestructura(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//1. Configurar el esquema de Autentificacion JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

//Agregar CORS

builder.Services.AddCors();

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

//Configurar CORS

app.UseCors(x => {
    x.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials();
});

//2. registra el middleware que usa los esquemas de autenticación registrados
app.UseAuthentication();
app.UseAuthorization();


app.Run();
