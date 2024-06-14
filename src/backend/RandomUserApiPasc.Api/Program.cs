using RandomUserApiPasc.Application.Interface;
using RandomUserApiPasc.Application.Services;
using RandomUserApiPasc.Infra.DAO;
using RandomUserApiPasc.Infra.Interfaces;
using RandomUserApiPasc.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()  
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRandomService, UserRandomService>();
builder.Services.AddTransient<IUserRandomRepository, UserRandomRepository>();
builder.Services.AddTransient<IUserRandomDAO, UserRandomDAO>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
