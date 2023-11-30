using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail
{
	//public class GetLeaveTypeDetailsQueryRequest : IRequest<LeaveTypeDetailsDto>
	//{
	//	public int Id { get; set; }
	//}

	public record GetLeaveTypeDetailsQueryRequest(int Id) : IRequest<LeaveTypeDetailsDto>;
}