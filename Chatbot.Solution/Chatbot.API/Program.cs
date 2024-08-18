using Chatbot.API.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddHostedService<VerificarAtendimentoService>();
var app = builder.Build();
app.Configure();
app.Run();
