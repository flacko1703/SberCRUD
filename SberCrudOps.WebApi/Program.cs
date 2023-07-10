using SberCrudOps.Application;
using SberCrudOps.Domain;
using SberCrudOps.Infrastructure;
using SberCrudOps.Shared;
using SberCrudOps.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddShared()
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",builder =>
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ResponseTimeMiddleware>();
app.UseShared();

app.UseCors("Policy");

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();



app.MapControllers();

app.Run();