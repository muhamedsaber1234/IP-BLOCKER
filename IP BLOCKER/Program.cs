using Bussiness_logic.Services;
using Dataacsess.IRepositories;
using Dataacsess.Repositories;
using Dataacsess.IRepositories;
using Microsoft.Extensions.Configuration;
namespace IP_BLOCKER
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            builder.Services.AddSingleton<IConfiguration>(config);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<GeolocationService>();

            builder.Services.AddSingleton<IBlockedCountryRepository, BlockedCountryRepository>();
            builder.Services.AddSingleton<ITemporalBlockRepository, TemporalBlockRepository>();
            builder.Services.AddSingleton<IBlockedAttemptLogRepository, BlockedAttemptLogRepository>();

            builder.Services.AddSingleton<BlockedCountryService>();
            builder.Services.AddSingleton<TemporalBlockService>();
            builder.Services.AddSingleton<BlockedAttemptLogService>();
            builder.Services.AddHostedService<TemporalBlockCleanupService>();
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
        }
    }
}
