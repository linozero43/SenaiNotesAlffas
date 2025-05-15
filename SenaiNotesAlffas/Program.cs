using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


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
                policy.WithOrigins("http://localhost:5500");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
        );
    }
);

var app = builder.Build();

app.UseCors("minhasOrigens");

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
