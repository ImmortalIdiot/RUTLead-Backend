using api.Data;
using api.Interfaces;
using api.Middleware;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalErrorHandling>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApiDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddCors(options => 
{
    options.AddPolicy("AndroidApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:6000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });

    options.AddPolicy("IosApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:6100");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });

    options.AddPolicy("WebApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:6200");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandling>();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("AndroidApp");
app.UseCors("IosApp");
app.UseCors("WebApp");

app.Run();
