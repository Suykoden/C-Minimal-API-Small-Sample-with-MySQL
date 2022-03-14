
using ProjetoInicial.Data;
using ProjetoInicial.Factories;
using ProjetoInicial.LibGenerica;
using ProjetoInicial.Models.Entidades;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<UsuarioContext>();

builder.Services.AddScoped<ILibGenerica, LibGenerica>();
builder.Services.AddScoped<IFactoryBase<Usuario>, UsuarioFactory>();

var app = builder.Build();
app.MapControllers();


app.Run();
