using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OmnichannelUser.Application.AutoMapper;
using OmnichannelUser.Application.Commands;

namespace OmnichannelUser.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddAutoMapper(typeof(ConfigurationMapping));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        return services;
    }
}
