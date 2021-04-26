using BigRoom.Service.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Validators
{
    class GroupPermissionValidator : AbstractValidator<GroupPermissionDto>
    {
        public GroupPermissionValidator()
        {
            RuleFor(a => a.QuizeId).NotEmpty();
            RuleFor(a => a.GroupId).NotEmpty();
            RuleFor(a => a.UserProfileId).NotEmpty();

        }
    }
}
