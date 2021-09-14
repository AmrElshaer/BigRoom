using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
namespace BigRoom.Service.DTO
{
    public class UserProfileDto : EntityDto,IMapFrom
    {
        public UserProfileDto()
        {
            Degrees = new HashSet<DegreeDto>();
            Groups = new HashSet<UserGroupsDto>();
            GroupsThatAdmin = new HashSet<GroupDto>();
            QuizesCreate = new HashSet<QuizeDto>();
        }
        public string UserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public ICollection<DegreeDto> Degrees { get; set; }
        public ICollection<UserGroupsDto> Groups { get; set; }
        public ICollection<GroupDto> GroupsThatAdmin { get; set; }
        public ICollection<QuizeDto> QuizesCreate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
        }
    }
}
