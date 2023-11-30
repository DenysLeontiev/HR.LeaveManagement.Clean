using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.CreateLeaveType
{
	public record CreateLeaveTypeCommandRequest(string Name, int DefaultDays) : IRequest<int>; // return type
}
