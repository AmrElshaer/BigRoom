using AutoMapper;
using BigRoom.Model.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public  class UserProfileService:IUserProfileService
    {
        private readonly IUniteOfWork uniteOfWork;
        private readonly IUserProfileRepository userProfileRepository;
        private readonly IMapper mapper;

        public UserProfileService(IUniteOfWork uniteOfWork, IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            this.uniteOfWork = uniteOfWork;
            this.userProfileRepository = userProfileRepository;
            this.mapper = mapper;
        }
        public async Task AddUserProfileAsync(string userId)
        {
           await  this.userProfileRepository.AddAsync(new UserProfile() { UserId=userId});
           await  uniteOfWork.SaveChangesAsync();
        } 
        public async Task<UserProfileDto> GetUserProfileAsync(string identityId)
        {
            var userProfile=  await this.userProfileRepository.GetUserProfileAsync(identityId);
            return mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
