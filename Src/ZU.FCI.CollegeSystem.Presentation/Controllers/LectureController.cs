using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Utilities;
using ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Commands.InsertLecture;
using ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Commands.UploadLectureFile;
using ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Queries.GetLecture;
using ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Queries.GetLectureFileInformation;
using ZU.FCI.CollegeSystem.DataAccess.Enums;
using ZU.FCI.CollegeSystem.Presentation.ApiRoutes;

namespace ZU.FCI.CollegeSystem.Presentation.Controllers;

[Route(ApiRoute.Lectures.Base)]
[ApiController]
public class LectureController : BaseController
{
    private readonly UserUtility _userUtility;

    public LectureController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    [HttpGet(ApiRoute.Lectures.Get)]
    public async Task<IActionResult> GetLecture([FromRoute] int id)
    {
        var result = await _sender.Send(new GetLectureQuery(id));

        return result.IsSuccess ?
            HandleSuccess(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpGet(ApiRoute.Lectures.GetFileInf)]
    public async Task<IActionResult> GetLectureFileInformation([FromQuery] int lectureId, [FromQuery] int fileId)
    {
        var result = await _sender.Send(new GetLectureFileInformationQuery(lectureId, fileId));

        return result.IsSuccess ?
            HandleSuccess(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoute.Lectures.Insert)]
    public async Task<IActionResult> InsertLecture([FromBody] InsertLectureCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            HandleSuccess("Lecture inserted successfully") :
            HandleFailure(result);
    }

    [HttpPost(ApiRoute.Lectures.UploadFile)]
    [Authorize(Roles = nameof(ApplicationRoles.Doctor))]
    public async Task<IActionResult> UploadFile(int lectureId, IFormFile file)
    {
        var getUserId = _userUtility.GetUserId();

        if (getUserId is null)
            return Unauthorized();

        var result = await _sender.Send(new UploadLectureFileCommand(file, lectureId, getUserId.Value));

        return result.IsSuccess ?
            HandleSuccess("File Uploaded Successfully") :
            HandleFailure(result);
    }
}