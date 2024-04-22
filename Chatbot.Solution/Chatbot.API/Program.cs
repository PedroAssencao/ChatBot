using Chatbot.API.DAL;

using Chatbot.API.HttpMethods;
using Chatbot.API.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Chatbot.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuarios/Index";
        options.Cookie.Name = "UsuarioDados";
        options.LogoutPath = "/Usuarios/Logout";
        options.AccessDeniedPath = "/Usuarios/Index";
    });
builder.Services.AddTransient<MethodsPost>();
builder.Services.AddTransient<MensagemRepository>();
builder.Services.AddTransient<ContatoRepository>();
builder.Services.AddTransient<LoginRepository>();
builder.Services.AddTransient<AtendimentoRepository>();
builder.Services.AddTransient<atendentesRepostiroy>();
builder.Services.AddTransient<DepartamentoRepository>();
builder.Services.AddTransient<optionsRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<menuRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5501") // Permite apenas essa origem
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<chatbotContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chinook"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

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
