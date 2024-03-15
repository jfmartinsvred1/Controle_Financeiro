using Controle_Financeiro.Authorization;
using Controle_Financeiro.Data;
using Controle_Financeiro.Models;
using Controle_Financeiro.Services;
using Controle_Financeiro.Services.DespesaService;
using Controle_Financeiro.Services.TokenService;
using Controle_Financeiro.Services.UsuarioService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = (builder.Configuration.GetConnectionString("ControleFinanceiroConnection"));

builder.Services.AddDbContext<ControleFinanceiroContext>(opts => opts.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<Usuario, IdentityRole>().
    AddEntityFrameworkStores<ControleFinanceiroContext>().
    AddDefaultTokenProviders() ;
builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

builder.Services.AddControllers().AddNewtonsoftJson
    (opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("32O4B23GO4BG234JBHHJBJ34")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("IdadeMinima", opts =>
    {
        opts.AddRequirements(new IdadeMinima(16));
    }
    );
});

builder.Services.
    AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<DespesaService>();
builder.Services.AddScoped<ReceitaService>();
builder.Services.AddScoped<ResumoService>();    
builder.Services.AddScoped<TokenServices>();


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


app.MapControllers();

app.Run();
