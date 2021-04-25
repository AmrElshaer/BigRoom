using AutoMapper;
using BigRoom.Repository.Contexts;
using BigRoom.Service.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.DTO
{
    public class ApplicationUserDto : IMapFrom
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, ApplicationUserDto>();
        }
    }
}
