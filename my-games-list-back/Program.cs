using Microsoft.EntityFrameworkCore;
using my_games_list_back.Data;
using my_games_list_back.Features.Users;
using my_games_list_back.Helpers.PasswordHash;
using my_games_list_back.Repository;
using my_games_list_back.Repository.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyGameListContext>
	(options => options.UseSqlServer
	(builder.Configuration.GetConnectionString("SQLConnection")));

builder.Services.AddScoped<IPasswordHash, PasswordHash>();
//builder.Services.AddSingleton<PasswordHash>();	
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(configure: endpoints =>
{

endpoints.MapControllers();
});


app.Run();
