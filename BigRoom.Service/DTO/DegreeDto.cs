using AutoMapper;
using BigRoom.Model.Common;
using BigRoom.Model.Entities;
using BigRoom.Service.Common.Mappings;
using BigRoom.Service.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.DTO
{
    public class DegreeDto:EntityDto,IMapFrom
    {
        public QuizeDto Quize { get; set; }
        public int? QuizeId { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfileDto UserProfile { get; set; }
        public int ExamDegree { get; set; }
        public int TotalDegree { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Degree,DegreeDto>();
        }
    }
}
