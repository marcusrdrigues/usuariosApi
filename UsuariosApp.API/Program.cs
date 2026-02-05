using Scalar.AspNetCore;
using UsuariosApp.Domain.Interfaces;
using UsuariosApp.Domain.Profiles;
using UsuariosApp.Domain.Services;
using UsuariosApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

#region Configurando a biblioteca do Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Configurar as injeções de dependência do projeto

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<UsuarioService>();
builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<UsuarioProfile>();
});

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

#region Habilitando o Swagger e o Scalar

app.UseSwagger();
app.UseSwaggerUI();
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

#endregion

app.UseAuthorization();
app.MapControllers();
app.Run();
