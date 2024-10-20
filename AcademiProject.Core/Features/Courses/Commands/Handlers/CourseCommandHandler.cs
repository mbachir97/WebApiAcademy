using AcademiProject.Core.Features.Courses.Commands.Modules;

using MediatR;
using MediatR.Pipeline;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Core.Basic;
using AcademiProject.Service.Abstraction;
using AutoMapper;
namespace AcademiProject.Core.Features.Courses.Commands.Handlers
{
    public class CourseCommandHandler : ResponseHandler,
        IRequestHandler<AddCourseCommand, Response<Course>>, 
        IRequestHandler<EditCouresCommand, Response<Course>> , 
        IRequestHandler<DeleteCourseCommand , Response<string>>
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseCommandHandler(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<Response<Course>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);

            var result = await _courseService.AddAsync(course);
            if (result.Id == 0) { return UnprocessableEntity(course, "this entity is already exist"); }
            else
            {
                return Created<Course>(result);
            }
        }

        public async Task<Response<Course>> Handle(EditCouresCommand request, CancellationToken cancellationToken)
        {
            var response = await  _courseService.GetCourseByIdAsync(request.Id);
            if (response is null) return NotFound<Course>($"The course with id = {request.Id} is not found ");

            var course = _mapper.Map<Course>(request); 

            response = await _courseService.UpdateCourseAsync(course);

            if (response is not null) return
                    Created<Course>(response, "the entity is updated succefuly");

            return BadRequest<Course>("Bad Request ");
        }

        public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
           var course =  await _courseService.GetCourseByIdAsync(request.Id);
            if (course is null) return NotFound<string>("this entity is not found to deleted");

            var result =   await _courseService.DeleteCourseAsync(course);
            return result == "succeees" ? Deleted<string>() : BadRequest<string>();  
        }
    }
}
