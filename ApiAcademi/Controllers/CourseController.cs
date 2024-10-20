using AcademiProject.Core.Features.Courses.Commands.Modules;
using AcademiProject.Core.Features.Courses.Queries.Modules;
using AcademiProject.Core.Features.Courses.Queries.Result;
using ApiAcademi.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPaternWithUOW.Core.Interfaces;
using RepositoryPaternWithUOW.Core.Model;
using System.Linq;

namespace ApiAcademi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : AppControllerBase
    {
        private readonly ICourseRepository _CourseRepository;

        public CourseController(ICourseRepository CourseRepository, IMediator mediator) : base(mediator)
        {
            _CourseRepository = CourseRepository;

        }

        [HttpGet]

        public async Task<IActionResult> GetById(int id)
        {


            return Ok(await _CourseRepository.GetByIdAsync(id));
        }


        [HttpGet("Courses")]
        public async Task<IActionResult> GetAll()
        {
            //var response = await _mediator.Send(new GetCourseListQuery());
            return NewResult(await _mediator.Send(new GetCourseListQuery()));
            //return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var response = await _mediator.Send(new GetCourseByIdQuery { Id = id });
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseCommand command)
        {
            var response = await _mediator.Send(command);

            return NewResult(response);
            // bettre than below 
            return response.StatusCode == System.Net.HttpStatusCode.Created ? Ok(response) : BadRequest(response.Message);

        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditCouresCommand cammand)
        {
            var response = await _mediator.Send(cammand);
            return NewResult(response);
        }
        [HttpDelete("{id}")]
       public  async Task<IActionResult> Delete( [FromRoute] int  id)
        {
              var response  =  await _mediator.Send(new DeleteCourseCommand { Id = id});       

               return NewResult(response);      
        }

        [HttpGet("Paginate")]
        public async Task<IActionResult> PaginateCourse([FromQuery] GetCoursePaginateListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }








    }
}
