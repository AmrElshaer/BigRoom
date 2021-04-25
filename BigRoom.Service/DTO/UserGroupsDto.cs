using AutoMapper;
using BigRoom.Repository.Common;
using BigRoom.Repository.Entities;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.DTO
{
    public  class UserGroupsDto:EntityDto,IMapFrom
    {
        public UserProfileDto UserProfile { get; set; }
        public int? UserProfileId { get; set; }
        public int? GroupId { get; set; }
        public GroupDto Group { get; set; }
        public string CodeJoin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserGroupsDto, UserGroups>().ReverseMap();
        }
    }
}
