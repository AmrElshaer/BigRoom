using AutoMapper;
using BigRoom.Repository;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BigRoom.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            AssemblyScanner.FindValidatorsInAssembly(typeof(GroupValidator).Assembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddRepository(configuration);
            services.AddAllService();
            //Mail Configration
            var mailSetting = configuration.GetSection(nameof(MailSettings));
            services.Configure<MailSettings>(a => {
                a.DisplayName = mailSetting[nameof(MailSettings.DisplayName)];
                a.Host = mailSetting[nameof(MailSettings.Host)];
                a.Password = mailSetting[nameof(MailSettings.Password)];
                a.Port = Convert.ToInt32(mailSetting[nameof(MailSettings.Port)]);
                a.Mail = mailSetting[nameof(MailSettings.Mail)];
            });
            return services;
        }
    }
}
