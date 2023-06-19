using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OmnichannelUser.Application.ZipCode;
using OmnichannelUser.Domain.UserAggregate;
using OmnichannelUser.Infrastructure.Repositories;
using OmnichannelUser.Infrastructure.ZipCode;

namespace OmnichannelUser.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
    {
        services.AddScoped<IZipCodeFinder, ZipCodeFinder>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
