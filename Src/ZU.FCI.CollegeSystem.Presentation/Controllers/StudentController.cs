using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Login;
using ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Students.Register;
using ZU.FCI.CollegeSystem.BusinessLogic.Students.Queries.GetStudent;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : BaseController
{
    public StudentController(ISender sender) : base(sender)
    {
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var result = await _sender.Send(new GetStudentQuery(id));

        return result.IsSuccess ?
            HandleSuccess(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] StudentRegisterCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            HandleSuccess("Student registered successfully.") :
            HandleFailure(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] StudentLoginCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            HandleSuccess(result.Successes.FirstOrDefault()?.Message!) :
            HandleFailure(result);
    }
}