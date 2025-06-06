using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Repositories;


var builder = WebApplication.CreateBuilder(args);

// para tirar looping do jadon no listar
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});


builder.Services.AddDbContext<NoteSenaiContext>();
builder.Services.AddTransient<IAnotacaoRepository, AnotacaoRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepositoy>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name:"minhasOrigens",
            policy =>
            {
                //TODO: Alterar link
                policy.WithOrigins("http://localhost:5173", "http://localhost:5173");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
        );
    }
);

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "senaiNotes",
        ValidAudience = "senaiNotes",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("minhasOrigens");

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseAuthentication();

app.UseAuthorization();

var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

if (!Directory.Exists(pastaDestino))
    Directory.CreateDirectory(pastaDestino);

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider (pastaDestino),
        RequestPath = "/image"
    }
    );

app.Run();
