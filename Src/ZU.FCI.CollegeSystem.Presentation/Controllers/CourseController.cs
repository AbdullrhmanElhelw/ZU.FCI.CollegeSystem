using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.InsertCourse;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetAllCourses;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetCourse;
using ZU.FCI.CollegeSystem.Presentation.ApiRoutes;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route(ApiRoute.Courses.Base)]
[ApiController]
public class CourseController : BaseController
{
    public CourseController(ISender sender) : base(sender)
    {
    }

    [HttpGet(ApiRoute.Courses.Get)]
    public async Task<IActionResult> GetCourse(int id)
    {
        var result = await _sender.Send(new GetCourseQuery(id));

        return result.IsSuccess ?
            HandleSuccess("Course Response", result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpGet(ApiRoute.Courses.GetAll)]
    public async Task<IActionResult> GetCourses()
    {
        var result = await _sender.Send(new GetCoursesQuery());

        return result.IsSuccess ?
            HandleSuccess("Courses Response", result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoute.Courses.Insert)]
    public async Task<IActionResult> InsertCourse([FromBody] InsertCourseCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            HandleSuccess(result.Successes.FirstOrDefault()?.Message!) :
            HandleFailure(result);
    }
}