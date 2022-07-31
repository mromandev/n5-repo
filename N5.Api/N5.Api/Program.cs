using Microsoft.EntityFrameworkCore;
using N5.Api.Controllers;
using N5.Api.Entity;
using N5.Api.Interfaces.Repository;
using N5.Api.Interfaces.Service;
using N5.Api.Repository;
using N5.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDbContext<N5DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("n5database"));
});

builder.Services.AddTransient<IPermissionsService, PermissionsService>();
builder.Services.AddTransient<IPermissionsTypesService, PermissionTypesService>();
builder.Services.AddTransient<IPermissionsRepository, PermissionsRepository>();
builder.Services.AddTransient<IPermissionsTypesRepository, PermissionTypesRepository>();

//builder.Services.AddDbContext<N5DbContext>();

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

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowAnyOrigin());

app.Run();
