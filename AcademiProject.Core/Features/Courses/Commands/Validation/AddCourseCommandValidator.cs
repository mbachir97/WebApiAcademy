using AcademiProject.Core.Features.Courses.Commands.Modules;
using AcademiProject.Service.Abstraction;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiProject.Core.Features.Courses.Commands.Validation
{
    public  class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
    {
        private readonly ICourseService _courseService;
        public AddCourseCommandValidator(ICourseService courseService)
        {
            _courseService = courseService;
            RuleFor(p => p.CourseName).NotEmpty().WithMessage("the name should not be empty or null");
            RuleFor(p => p.Price).GreaterThan(150m).WithMessage("the price  should be grater than 150$ ");
            
            RuleFor(p => p.CourseName).MustAsync( IsNameExist)
                .WithMessage("the name is already exist chibaniya rahi raya");
          
        }

        private  async Task<bool> IsNameExist(string name , CancellationToken cancellationToken )
        {
              return ! await _courseService.IsCourseExistByName(name);   
        }
    }
}
