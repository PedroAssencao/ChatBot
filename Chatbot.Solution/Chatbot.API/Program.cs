using Chatbot.API.DAL;

using Chatbot.API.HttpMethods;
using Chatbot.API.Repository;
//using Chatbot.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MethodsPost>();
builder.Services.AddScoped<MensagemRepository>();
builder.Services.AddScoped<ContatoRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<AtendimentoRepository>();
builder.Services.AddScoped<atendentesRepostiroy>();
builder.Services.AddScoped<DepartamentoRepository>();
builder.Services.AddDbContext<chatbotContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chinook"));

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

app.Run();
