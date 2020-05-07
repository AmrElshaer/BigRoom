
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BigRoom.Areas.Identity.IdentityHostingStartup))]
namespace BigRoom.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}