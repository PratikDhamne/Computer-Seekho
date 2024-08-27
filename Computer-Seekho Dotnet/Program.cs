
using ComputerSeekho.Repository;
using ComputerSeekho.Service;
using Microsoft.EntityFrameworkCore;

namespace ComputerSeekho
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAlbumservice,AlbumService>();
            builder.Services.AddScoped<IBatchService, BatchService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IClosureReasonService, ClosureReasonService>();
            builder.Services.AddScoped<IEnquiryService, EnquiryService>();
            builder.Services.AddScoped<IFollowupService, FollowupService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            builder.Services.AddScoped<IReceiptService, ReceiptService>();
            builder.Services.AddScoped<IStaffService, StaffService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IVideoService, VideoService>();
            builder.Services.AddDbContext<Appdbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ComputerSeekhoDBConnection")), ServiceLifetime.Transient);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                    });
            });

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
            app.UseCors("AllowReactApp");
            app.Run();
        }
    }
}
