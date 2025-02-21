using cs_exercise_todolist_api.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<appDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString")));
builder.Services.AddDbContext<appDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PsqlConnectionString")));

builder.Services.AddScoped<appDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("*")  // Defina a origem permitida
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{ // Garante que o banco de dados existe antes de terminar a inicialização
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<appDbContext>();
    dbContext!.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.Run();
