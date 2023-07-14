using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;
using WebApplication1.Services;
using WebApplication1.Models;
using Host = WebApplication1.Models.Host;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", opts =>
    {
        opts.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddDbContext<AaladinContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("empCon"));
});

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRepo<int, Customer>, CustomerDbRepo>();
builder.Services.AddScoped<IRepo<int, Questionary>, QuestionaryDbRepo>();
builder.Services.AddScoped<IRepo<int, Host>, HostDbRepo>();
builder.Services.AddScoped<IRepo<int, HomeStay>, HomeStayDbRepo>();
builder.Services.AddScoped<IRepo<string, User>, UserRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
