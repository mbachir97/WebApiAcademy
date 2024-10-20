using AcademiProject.Core.Features.Courses.Commands.Modules;
using AcademiProject.Service.Abstraction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Features.Courses.Commands.Validation
{
    public class EditCourseCommandValidator : AbstractValidator<EditCouresCommand>
    {
        private readonly ICourseService _courseService;
        public EditCourseCommandValidator(ICourseService courseService)
        {
            _courseService = courseService;
            RuleFor(p => p.CourseName).NotEmpty().WithMessage("the name should not be empty or null");
            RuleFor(p => p.Price).GreaterThan(150m);

            RuleFor(p => p.CourseName).MustAsync(IsNameExist)
                .WithMessage("the name is already exist ");

           
        }

        private async Task<bool> IsNameExist(EditCouresCommand model ,string name, CancellationToken cancellationToken)
        {
            return !await _courseService.IsCourseExistByName(model.Id , name);
        }
    }
}
