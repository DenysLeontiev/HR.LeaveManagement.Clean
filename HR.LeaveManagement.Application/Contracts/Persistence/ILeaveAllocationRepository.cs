// Contracts/Persistence stores interfaces which manage data access
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
	public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
	{
		Task<LeaveAllocation> GetAllLeaveAllocationWithDetails(int id);
		Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails();
		Task<List<LeaveAllocation>> GetAllLeaveAllocationsWithDetails(string userId);
		Task<bool> AllocationExists(string userId, string leaveTypeId, int period);
		Task AddAllocations(List<LeaveAllocation> allocations);
		Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
	}
}
