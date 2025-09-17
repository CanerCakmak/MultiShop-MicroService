using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Order.Application;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerURL"];
        options.Audience = "ResourceOrder";
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddDbContext<OrderDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
