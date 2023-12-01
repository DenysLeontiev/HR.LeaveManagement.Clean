using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistance.DatabaseContext.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(HrDatabaseContext context) : base(context)
		{

		}
		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.LeaveTypes.AnyAsync(t => t.Name.Equals(name));
		}
	}
}
