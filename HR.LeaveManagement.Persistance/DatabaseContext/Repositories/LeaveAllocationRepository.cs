using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistance.DatabaseContext.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
		{
		}

		public async Task AddAllocations(List<LeaveAllocation> allocations)
		{
			await _context.LeaveAllocations.AddRangeAsync(allocations);
		}

		public async Task<bool> AllocationExists(string userId, string leaveTypeId, int period)
		{
			return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId.Equals(userId)
														&& x.LeaveTypeId.Equals(leaveTypeId)
														&& x.Period.Equals(period));
		}

		public async Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails()
		{
			return await _context.LeaveAllocations.Include(x => x.LeaveType).ToListAsync();
		}

		public async Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails(string userId)
		{
			return await _context.LeaveAllocations.Where(x => x.EmployeeId.Equals(userId))
										 .Include(x => x.LeaveType)
										 .ToListAsync();
		}

		public async Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int id)
		{
			return await _context.LeaveAllocations.Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
		{
			return await _context.LeaveAllocations.Include(x => x.LeaveType)
										 .FirstOrDefaultAsync(x => x.EmployeeId.Equals(userId) 
															&& x.LeaveTypeId == leaveTypeId);

		}
	}
}
