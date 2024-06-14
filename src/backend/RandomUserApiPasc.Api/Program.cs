using RandomUserApiPasc.Application.Interface;
using RandomUserApiPasc.Application.Services;
using RandomUserApiPasc.Infra.Interfaces;
using RandomUserApiPasc.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRandomService, UserRandomService>();
builder.Services.AddTransient<IUserRandomRepository, UserRandomRepository>();

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
