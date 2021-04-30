using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Validators
{
    public class UserGroupValidator:AbstractValidator<UserGroupsDto>
    {
        public UserGroupValidator(IUserGroupService userGroupService,IGroupService groupService)
        {
            RuleFor(g => g.CodeJoin).Must(userGroupService.IsExist).WithMessage("CodeJoin  is Not Exits Please Enter valid CodeJoin");
            RuleFor(g => g).Custom((g, context) => {
                var group = groupService.GetGroupByCodeAsync(g.CodeJoin).GetAwaiter().GetResult();
                g.GroupId = group?.Id;
                if (group != null && userGroupService.UserIsJoinGroup(group.Id, g.UserProfileId.Value))
                {
                    context.AddFailure("You are Exiting in This group");
                }
            });
            
        }
    }
}
