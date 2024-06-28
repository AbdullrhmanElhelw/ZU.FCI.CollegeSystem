using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Data;
using ZU.FCI.CollegeSystem.DataAccess.Data.Infrastructure;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Repository;

namespace ZU.FCI.CollegeSystem.DataAccess;

public static class DataAccessDependencies
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionString.DefaultConnection)
                                  ?? throw new ArgumentNullException("Connection string is missing in appsettings.json");

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<CollegeSystemDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ICollegeSystemDbContext>(sp =>
            sp.GetRequiredService<CollegeSystemDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<CollegeSystemDbContext>());

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}