using Microsoft.EntityFrameworkCore;
using WebAPI.Data; // Import ~/WebAPI/Data
using System.Text.Json.Serialization; // Import System.Text.Json.Serialization để sử dụng ReferenceHandler.IgnoreCycles

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* Đăng ký EF Core với SQL Server
- MyDbContext nằm ở trong folder Data
- UseSqlServer(connectionString) được sử dụng để cấu hình EF Core sử dụng SQL Server với chuỗi kết nối đã lấy từ appsettings.json
 */

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // UserSwagger và UseSwaggerUI để test API
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles(); // UseDefaultFiles và UseStaticFiles để phục vụ các file tĩnh như HTML, CSS, JS => mở index.html


app.MapControllers(); // map route API  
app.Run();
