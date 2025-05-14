using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Repositories;

using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<NoteSenaiContext>();
builder.Services.AddTransient<IAnotacaoRepository, AnotacaoRepository>();
//builder.Services.AddTransient<ITagRepository, TagRepository>();
//builder.Services.AddDbContext<NoteSenaiContext>();
//builder.Services.AddTransient<IAnotacaoRepository, AnotacaoRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
//builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
