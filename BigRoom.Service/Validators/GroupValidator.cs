using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Service.Validators
{
    public class GroupValidator:AbstractValidator<GroupDto>
    {
        public GroupValidator(IGroupService groupService)
        {
            RuleFor(g => g.CodeJion).NotEmpty();
            RuleFor(g => g.Name).NotEmpty().Must(groupService.IsUniqueName).WithMessage("Name Groups is Exits Please Enter another name");
            
        }
    }
}
