﻿using AutoMapper;
using BigRoom.Repository.Common;
using BigRoom.Repository.Entities;
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
            GroupPermissions = new HashSet<GroupPermissionDto>();
        }
        [Display(Name = "CodeJoin")]
        public string CodeJion { get; set; }
        public string Name { get; set; }
        public ICollection<QuizeDto> Quizes { get; set; }
        public ICollection<UserGroupsDto> Groups { get; set; }
        public int AdminId { get; set; }
        public UserProfileDto Admin { get; set; }
        public ICollection<GroupPermissionDto> GroupPermissions { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
