using Toy.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 프로젝트의 모든 프로필 클래스를 검색하도록 지정
builder.Services.AddAutoMapper(typeof(Program)); 

// Add services to the container.
builder.Services.AddApplicationContexts();
builder.Services.AddApplicationRepositories();
builder.Services.AddApplicationQueryService();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP queryDto pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();