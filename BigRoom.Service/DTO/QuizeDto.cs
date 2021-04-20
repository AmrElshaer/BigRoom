using AutoMapper;
using BigRoom.Model.Common;
using BigRoom.Model.Entities;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace BigRoom.Service.DTO
{
    public class QuizeDto : AuditableEntityDto,IMapFrom
    {
        public QuizeDto()
        {
            Degrees = new HashSet<DegreeDto>();
            UsersDoExam = new HashSet<UserProfileDto>();
        }

        public ICollection<DegreeDto> Degrees { get; set; }
        public string Description { get; set; }
        public IFormFile FileQuestion { get; set; }
        public IFormFile FileAnswerForm{ get; set; }
        public string File { get; set; }
        public string Fileanswer { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
      
        public DateTime TimeEnd { get; set; }

        public DateTime TimeStart { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfileDto UserProfile { get; set; }
        public ICollection<UserProfileDto> UsersDoExam { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Quize, QuizeDto>().ReverseMap();
        }
    }
}