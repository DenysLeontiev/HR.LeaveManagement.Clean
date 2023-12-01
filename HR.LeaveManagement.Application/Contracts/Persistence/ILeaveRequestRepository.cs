// Contracts/Persistence stores interfaces which manage data access
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
	public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
	{
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
	}
}
