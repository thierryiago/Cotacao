using IaraCotacoes.Data;
using IaraCotacoes.Repositories;
using IaraCotacoes.Repositories.Interfaces;
using IaraCotacoes.Services;
using IaraCotacoes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICotacaoService, CotacaoService>();
builder.Services.AddScoped<ICotacaoRepository, CotacaoRepository>();

builder.Services.AddScoped<ICotacaoItemService, CotacaoItemService>();
builder.Services.AddScoped<ICotacaoItemRepository, CotacaoItemRepository>();


var connectionString = builder.Configuration.GetConnectionString("ConnectionCotacao");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cotacoes", Version = "v1" });
});

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
