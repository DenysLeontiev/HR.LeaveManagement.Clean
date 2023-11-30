using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes
{
	public class GetAllLeaveTypesQueryRequest : IRequest<List<LeaveTypeDto>>
	{
	}
}
