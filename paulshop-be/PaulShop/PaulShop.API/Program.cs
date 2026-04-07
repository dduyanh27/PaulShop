using Microsoft.EntityFrameworkCore;
using PaulShop.API.Models;
using PaulShop.API.Services;

namespace PaulShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Đăng ký Services
            builder.Services.AddScoped<MinioService>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<PaulShopContext>(options =>
                options.UseSqlServer(connectionString));

            // 2. Cấu hình CORS - Cho phép React truy cập
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PaulShopPolicy", // Đặt tên policy đồng nhất
                    policy => policy.WithOrigins("http://localhost:5174")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod());
            });

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 3. Cấu hình Pipeline (Thứ tự rất quan trọng)
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Kích hoạt CORS ngay đầu pipeline
            app.UseCors("PaulShopPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}