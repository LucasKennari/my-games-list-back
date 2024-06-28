using Microsoft.EntityFrameworkCore;
using my_games_list_back.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//==============//
//Configuracao do branco de dados,
//Aqui ele vai pegar todas as informacoes dentro da string SQLConnectio
//Essa string se encontra no json chamada "appSettings.json"

builder.Services.AddDbContext<MyGameListContext>
	(options => options.UseSqlServer
	(builder.Configuration.GetConnectionString("SQLConnection"))); 
//============//


var app = builder.Build();

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
