using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Queries.GetLeaveRequestList
{
	public class GetLeaveRequestListQueryRequest : IRequest<List<LeaveRequestListDto>>
	{
	}
}
