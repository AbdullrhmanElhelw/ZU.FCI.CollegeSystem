using FluentResults;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Commands.UploadLectureFile;

public sealed record UploadLectureFileCommand
    (IFormFile LectureFile,
     int LectureId,
     int DoctorId) : ICommand;

public sealed record UploadLectureFileCommandHandler :
    ICommandHandler<UploadLectureFileCommand>
{
    private readonly ILectureRepository _lectureRepository;
    private readonly ILectureFileRepository _lectureFileRepository;
    private readonly IUnitOfWork _unitOfwork;

    public UploadLectureFileCommandHandler(ILectureRepository lectureRepository,
                                           ILectureFileRepository lectureFileRepository,
                                           IUnitOfWork unitOfwork)
    {
        _lectureRepository = lectureRepository;
        _lectureFileRepository = lectureFileRepository;
        _unitOfwork = unitOfwork;
    }

    public async Task<Result> Handle(UploadLectureFileCommand request, CancellationToken cancellationToken)
    {
        var checkLectureIsExists = await _lectureRepository.GetLectureByIdAsync(request.LectureId, cancellationToken);

        if (checkLectureIsExists is null)
            return new Result().WithError(new RecordNotFoundError("Lecture not found"));

        using var memoryStream = new MemoryStream();

        await request.LectureFile.CopyToAsync(memoryStream, cancellationToken);

        var lectureFile = new LectureFile
        {
            Title = "Any Title",
            LectureId = request.LectureId,
            DoctorId = request.DoctorId,
            Content = memoryStream.ToArray(),
            Name = request.LectureFile.FileName,
            Extension = Path.GetExtension(request.LectureFile.FileName)
        };

        _lectureFileRepository.Insert(lectureFile);

        return await _unitOfwork.SaveChangesAsync(cancellationToken) == 0 ?
             Result.Fail("Failed To Save File") :
             Result.Ok();
    }
}

public sealed class UploadLectureFileValidator : AbstractValidator<UploadLectureFileCommand>
{
    public UploadLectureFileValidator()
    {
        RuleFor(x => x.LectureFile)
        .NotNull()
        .WithMessage("File is required")
        .Must(x => x.ContentType == "application/pdf" || x.ContentType == "application/msword" || x.ContentType == "application/vnd.ms-powerpoint")
        .WithMessage("File must be pdf, word or ppt")
        .Must(x => x.Length < 5 * 1024 * 1024)
        .WithMessage("File size must be less than 5 MB");

        RuleFor(x => x.LectureId)
            .GreaterThan(0)
            .WithMessage("LectureId is required");

        RuleFor(x => x.DoctorId)
            .GreaterThan(0)
            .WithMessage("DoctorId is required");
    }
}