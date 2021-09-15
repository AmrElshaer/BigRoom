using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using FluentValidation;
using System;

namespace BigRoom.Service.Validators
{
    public class UserGroupValidator : AbstractValidator<UserGroupsDto>
    {
        private readonly IUserGroupService userGroupService;
        private readonly IGroupService groupService;

        public UserGroupValidator(IUserGroupService userGroupService, IGroupService groupService)
        {
            this.userGroupService = userGroupService;
            this.groupService = groupService;
            RuleFor(g => g.CodeJoin).NotEmpty().NotNull();
            RuleFor(g => g).Must(IsGroupExist).WithMessage("CodeJoin  is Not Exits Please Enter valid CodeJoin")
           .DependentRules(() => { RuleFor(g => g).Must(UserNotInGroup).WithMessage("You May Exiting in This group"); });
            
            
        }

        private bool IsGroupExist(UserGroupsDto userGroupsDto)
        {
            try
            {
                return (groupService.GetFirstAsync(a => a.CodeJion == userGroupsDto.CodeJoin).GetAwaiter().GetResult()) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool UserNotInGroup(UserGroupsDto userGroupsDto)
        {

            var group = groupService.GetFirstAsync(a => a.CodeJion == userGroupsDto.CodeJoin).GetAwaiter().GetResult();
            userGroupsDto.GroupId = group.Id;
            var userGroup= userGroupService.GetFirstAsync((a => a.GroupId == group.Id
            && userGroupsDto.UserProfileId == userGroupsDto.UserProfileId)).GetAwaiter().GetResult();
            return userGroup == null;


        }
    }
}