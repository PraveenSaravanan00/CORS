using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CORS_web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CORS_webContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CORS_webContext") ?? throw new InvalidOperationException("Connection string 'CORS_webContext' not found.")));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();
app.UseCors("AllowOrigin");
app.MapControllers();

app.Run();
