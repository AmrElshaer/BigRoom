using BigRoom.Service.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BigRoom.Service.Validators
{
    public class QuizeValidator:AbstractValidator<QuizeDto>
    {
        public QuizeValidator()
        {
            RuleFor(q => q.TimeStart).NotEqual(default(DateTime)).LessThan(q=>q.TimeEnd).WithMessage("TimeStart must be less Than TimeEnd");
            RuleFor(q => q.TimeEnd).NotEqual(default(DateTime)).GreaterThanOrEqualTo(DateTime.Now).WithMessage("TimeEnd Should be Greater Than or equal Now");
            RuleFor(q => q.FileQuestion).Must(a=>a==null|| Path.GetExtension(a.FileName)==".csv").WithMessage("Question File must end with .csv");
            RuleFor(q => q.FileAnswerForm).Must(a =>a==null|| Path.GetExtension(a.FileName) == ".txt").WithMessage("Answer File must end with .txt");
            RuleFor(q => q).Custom((q, context) => {
                if (q.Hour ==null&& q.Minute == null)
                {
                    context.AddFailure("Hour","Must add value at least to hour or minute");
                }
            });
        }
    }
}
