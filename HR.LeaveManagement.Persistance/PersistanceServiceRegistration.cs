using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistance
{
    public static class PersistanceServiceRegistration 
	{
		public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<HrDatabaseContext>(opts => 
						opts.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString")));

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
			services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAllocationRepository));
			services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));

			return services;
		}
	}
}
