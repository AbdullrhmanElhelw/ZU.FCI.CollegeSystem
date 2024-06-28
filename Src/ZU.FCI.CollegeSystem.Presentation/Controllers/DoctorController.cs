using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Login;
using ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Register;
using ZU.FCI.CollegeSystem.Presentation.ApiRoutes;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route(ApiRoute.Doctors.Base)]
[ApiController]
public class DoctorController : BaseController
{
    public DoctorController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoute.Doctors.Login)]
    public async Task<IActionResult> LoginDoctor(DoctorLoginCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            HandleSuccess(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoute.Doctors.Register)]
    public async Task<IActionResult> RegisterDoctor(DoctorRegisterCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            HandleSuccess("Doctor Added To System Successfully") :
            HandleFailure(result);
    }
}