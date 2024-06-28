namespace ZU.FCI.CollegeSystem.Presentation.ApiRoutes;

public static class ApiRoute
{
    public static class Students
    {
        public const string Base = "api/students";
        public const string Login = "login";
        public const string Register = "register";
        public const string GetAll = "";
        public const string Get = "{id:int}";
        public const string Create = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id}";
    }

    public static class Courses
    {
        public const string Base = "api/courses";
        public const string GetAll = "";
        public const string Get = "{id:int}";
        public const string Insert = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id:int}";
    }

    public static class Doctors
    {
        public const string Base = "api/doctors";
        public const string Login = "login";
        public const string Register = "register";
        public const string GetAll = "";
        public const string Get = "{id:int}";
        public const string Create = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id:int}";
    }

    public static class Lectures
    {
        public const string Base = "api/lectures";
        public const string GetAll = "";
        public const string Get = "{id:int}";
        public const string Insert = "";
        public const string Update = "{id:int}";
        public const string Delete = "{id:int}";
        public const string UploadFile = "upload-file";
        public const string GetFileInf = "get-file-inf";
    }
}