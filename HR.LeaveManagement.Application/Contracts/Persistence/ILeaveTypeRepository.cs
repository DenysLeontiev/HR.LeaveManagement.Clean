// Contracts/Persistence stores interfaces which manage data access
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
	{
		
	}
}
