﻿using CharlieBackend.Business.Helpers;
using CharlieBackend.Core.DTO.StudentGroups;
using FluentValidation;

namespace CharlieBackend.Api.Validators.StudentGroupsDTOValidators
{
    public class UpdateStudentGroupDtoValidator : AbstractValidator<UpdateStudentGroupDto>
    {
        public UpdateStudentGroupDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(ValidationConstants.MaxLengthHeader);
            RuleFor(x => x.CourseId)
                .GreaterThan(0);
            RuleFor(x => x.FinishDate)
                .Must((x, cancellation) => (x.FinishDate > x.StartDate || x.FinishDate.Equals(x.StartDate)))
                .When(x => x.FinishDate != null)
                .WithMessage(ValidationConstants.DatesNotValid);
            RuleForEach(x => x.StudentIds)
                .NotEmpty()
                .GreaterThan(0);
            RuleForEach(x => x.MentorIds)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}