using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail
{
	public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDto>;
}