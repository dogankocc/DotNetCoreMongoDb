using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.OpenApi;
using Microsoft.Extensions.Configuration;
using WebApplication_MongoDb_Example.Helper;
using WebApplication_MongoDb_Example.Data;
using WebApplication_MongoDb_Example.Service;

namespace WebApplication_MongoDb_Example
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var builder = new ConfigurationBuilder().AddJsonFile("mongoDbSettings.json", optional: false, reloadOnChange: true);
            services.AddMongoDbSettings(builder.Build());
            services.AddSingleton<ITodoService, TodoService>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

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
