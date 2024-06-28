using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.InsertCourse;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetAllCourses;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Queries.GetCourse;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : BaseController
{
    public CourseController(ISender sender) : base(sender)
    {
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        var result = await _sender.Send(new GetCourseQuery(id));

        return result.IsSuccess ?
            HandleSuccess("Course Response", result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var result = await _sender.Send(new GetCoursesQuery());

        return result.IsSuccess ?
            HandleSuccess("Courses Response", result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertCourse([FromBody] InsertCourseCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            HandleSuccess(result.Successes.FirstOrDefault()?.Message!) :
            HandleFailure(result);
    }
}