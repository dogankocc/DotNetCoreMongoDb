using WebApplication_MongoDb_Example.Data;

namespace WebApplication_MongoDb_Example.Helper
{
    public static class Helper
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
           IConfiguration configuration)
        {
            string connString = configuration
                   .GetSection(nameof(MongoDbSettings) + ":ConnectionString").Value;
            string database = configuration
                    .GetSection(nameof(MongoDbSettings) + ":Database").Value;

            return services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = connString;
                options.Database = database;
            });
        }
    }
}
