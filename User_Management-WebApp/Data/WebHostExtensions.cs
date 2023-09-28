using Microsoft.Extensions.DependencyInjection;
using System;


namespace User_Management_WebApp.Data
{
    public static class WebHostExtensions
    {
        public static void RunWithSeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    UserRolesInitializer.InitializerAsync(services).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "An error occurred while seeding data");
                }
            }
        }
    }
}
