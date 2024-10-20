using AcademiProject.Core.Features.Courses.Queries.Modules;
using MediatR;
using RepositoryPaternWithUOW.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademiProject.Service.Abstraction;
using AcademiProject.Core.Features.Courses.Queries.Result;
using AutoMapper;

using AcademiProject.Core.Basic;
using AcademiProject.Core.Wrapper;
using System.Linq.Expressions;

namespace AcademiProject.Core.Features.Courses.Queries.Handlers
{
    public class CourseHandler : ResponseHandler,
        IRequestHandler<GetCourseByIdQuery, Response<GetSingleCourseResponse>>


        , IRequestHandler<GetCourseListQuery,
      Response<IEnumerable<GetCourseListResponse>>> 
        , IRequestHandler<GetCoursePaginateListQuery ,PaginateResult<GetCoursePaginateListResponse> >
    {


        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseHandler(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetCourseListResponse>>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var CourseList = await _courseService.GetAllCoursesAsync();

            var CourseResponse = _mapper.Map<IEnumerable<GetCourseListResponse>>(CourseList);

            return Success(CourseResponse);
        }

        public async Task<Response<GetSingleCourseResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseService.GetCourseByIdAsync(request.Id);

            if (course == null) return NotFound<GetSingleCourseResponse>($"ther is No Course with Id {request.Id}");

            var courseresponse = _mapper.Map<GetSingleCourseResponse>(course);
            return Success(courseresponse);
        }

        public async Task<PaginateResult<GetCoursePaginateListResponse>> Handle(GetCoursePaginateListQuery request, CancellationToken cancellationToken)
        {
            var querable = _courseService.GetFilterCourseQuerable(request.Search);
            Expression<Func<Course,GetCoursePaginateListResponse>> expression = e =>
            new GetCoursePaginateListResponse { CourseName = e.CourseName , 
                HoursToComplete = e.HoursToComplete , Price = e.Price , Id = e.Id , NumberOdSections = e.Sections.Count };

            var responsequerable = await querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return responsequerable;



        }
    }
}
