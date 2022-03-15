
using Microsoft.OpenApi.Models;
using ProjetoInicial.Data;
using ProjetoInicial.Factories;
using ProjetoInicial.LibGenerica;
using ProjetoInicial.Models.Entidades;
using ProjetoInicial.Repository.Usuarios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<UsuarioContext>();

builder.Services.AddScoped<ILibGenerica, LibGenerica>();
builder.Services.AddScoped<IFactoryBase<Usuario>, UsuarioFactory>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "v1" });
});

var app = builder.Build();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(opt =>
{
    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu Swagger V1");
});

app.Run();
