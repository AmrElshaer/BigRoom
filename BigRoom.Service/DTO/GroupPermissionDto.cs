using AutoMapper;
using BigRoom.Model.Entities;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.DTO
{
    public  class GroupPermissionDto: AuditableEntityDto,IMapFrom
    {
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfileDto UserProfile { get; set; }
        public int? QuizeId { get; set; }
        public QuizeDto Quize { get; set; }
        public bool Edit { get; set; }
        public bool Create { get; set; }
        public bool Delete { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GroupPermission,GroupPermissionDto>().ReverseMap();
        }
    }
}
