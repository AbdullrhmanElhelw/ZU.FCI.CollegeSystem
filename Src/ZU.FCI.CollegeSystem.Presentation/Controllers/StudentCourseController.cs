using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Utilities;
using ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.RegisterCourse;
using ZU.FCI.CollegeSystem.DataAccess.Enums;
using ZU.FCI.CollegeSystem.Presentation.ApiRoutes;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route(ApiRoute.StudentCourses.Base)]
[ApiController]
public class StudentCourseController : BaseController
{
    private readonly UserUtility _userUtility;

    public StudentCourseController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    [HttpPost(ApiRoute.StudentCourses.Register)]
    [Authorize(Roles = nameof(ApplicationRoles.Student))]
    public async Task<IActionResult> RegisterCourse([FromRoute] int courseId)
    {
        var studentId = _userUtility.GetUserId();
        if (studentId is null)
            return Unauthorized("Invalid Credentials");

        var result = await _sender.Send(new RegisterCourseCommand(courseId, studentId.Value));
        return result.IsSuccess ?
            HandleSuccess("Course Registered Successfully") :
            HandleFailure(result);
    }
}