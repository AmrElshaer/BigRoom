using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using FluentValidation;
using System;

namespace BigRoom.Service.Validators
{
    public class UserGroupValidator : AbstractValidator<UserGroupsDto>
    {
        public UserGroupValidator(IUserGroupService userGroupService, IGroupService groupService)
        {
            RuleFor(g => g.CodeJoin).NotEmpty().NotNull();
            RuleFor(g => g).Must(IsGroupExist).WithMessage("CodeJoin  is Not Exits Please Enter valid CodeJoin")
            .Must(UserInGroup).WithMessage("You May Exiting in This group");

            bool IsGroupExist(UserGroupsDto userGroupsDto)
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
            bool UserInGroup(UserGroupsDto userGroupsDto)
            {
                if (!IsGroupExist(userGroupsDto))
                    return false;

                var group = groupService.GetFirstAsync(a => a.CodeJion == userGroupsDto.CodeJoin).GetAwaiter().GetResult();
                var userGroup = userGroupService.GetFirstAsync((a => a.GroupId == group.Id
                && userGroupsDto.UserProfileId == userGroupsDto.UserProfileId)).GetAwaiter().GetResult();
                return group != null && userGroup != null;
            }
        }
    }
}