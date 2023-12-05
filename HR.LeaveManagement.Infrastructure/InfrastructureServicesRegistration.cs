using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Infrastructure.Logging;

namespace HR.LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

			return services;
		}

	}
}
