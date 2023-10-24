using Mongo.DL;
using Mongo.Model;
using Mongo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//LEGGE ED INIETTA LA CONFIGURAZIONE MONGO
builder.Services.Configure<MagazzinoDatabaseSettings>(
builder.Configuration.GetSection("MagazzinoDatabaseSettings"));

//INJECTION Context e Repository
builder.Services.AddScoped<MagazzinoDatabaseSettings, MagazzinoDatabaseSettings>();
builder.Services.AddScoped<IMagazzinoContext, MagazzinoContext>();
builder.Services.AddScoped<IProdottiService, ProdottiService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
