using LibraryWebAPI.DataAccess.Installers;
using LibraryWebAPI.BusinessLogic.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDataContext()
    .AddBooks()
    .AddAuthors()
    .AddLibraryFacade()
    .AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
