using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.Utils;
using ControleFinanceiro.Core.ValueObjects;
using ControleFinanceiro.Infrastructure.Configurations;
using ControleFinanceiro.Infrastructure.Data;
using ControleFinanceiro.Infrastructure.Mappings;
using ControleFinanceiro.Infrastructure.Security;
using Dapper.FluentMap;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

//Configuração JWT no swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Configuração de segurança para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no formato: Bearer {seuTokenAqui}",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
}
    );
builder.Services.AddSingleton<IDatabaseConfig, DatabaseConfig>();

builder.Services.AddScoped<SenhaHasher>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IReceitaService, ReceitaService>();
builder.Services.AddSingleton<IReceitaRepository, ReceitaRepository>();

builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddSingleton<IDespesaRepository, DespesaRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Key)),
        ValidateIssuer = false
    };
});

builder.Services.AddTransient<JwtService>();

builder.Services.AddAuthorization();

builder.Services.AddControllers();
Dapper.SqlMapper.AddTypeHandler(new EmailTypeHandler());

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

FluentMapper.Initialize(config =>
{
    config.AddMap(new UsuarioMap());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
    
app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
