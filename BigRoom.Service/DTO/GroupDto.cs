using AutoMapper;
using BigRoom.Model.Common;
using BigRoom.Model.Entities;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BigRoom.Service.DTO
{
    public class GroupDto: AuditableEntityDto,IMapFrom
    {
        public GroupDto()
        {
            Groups = new HashSet<UserGroupsDto>();
        }
        [Display(Name = "CodeJoin")]
        public string CodeJion { get; set; }
        public string Name { get; set; }
        public ICollection<QuizeDto> Quizes { get; set; }
        public ICollection<UserGroupsDto> Groups { get; set; }
        public int AdminId { get; set; }
        public UserProfileDto Admin { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
