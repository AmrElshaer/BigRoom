using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using BigRoom.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BigRoom.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BigRoomDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BigRoomDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            return services;
        }
    }
}