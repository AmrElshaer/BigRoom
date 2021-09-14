using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class UserProfileService : ServiceAsync<UserProfile, UserProfileDto>, IUserProfileService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryAsync<UserProfile> userProfileRepository;

        public UserProfileService(IUniteOfWork uniteOfWork, IRepositoryAsync<UserProfile> userProfileRepository
            , IMapper mapper) : base(uniteOfWork, userProfileRepository, mapper)
        {
            this.userProfileRepository = userProfileRepository;
            this.mapper = mapper;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(int id)
        {
            var userProfile = await this.userProfileRepository.Entities.Include(a => a.GroupsThatAdmin)
                .Include(a => a.Groups).ThenInclude(a => a.Group).FirstOrDefaultAsync(a => a.Id == id);
            return mapper.Map<UserProfileDto>(userProfile);
        }
    }
}