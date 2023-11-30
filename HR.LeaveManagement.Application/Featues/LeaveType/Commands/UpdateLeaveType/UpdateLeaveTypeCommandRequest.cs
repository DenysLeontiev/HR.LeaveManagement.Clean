using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.UpdateLeaveType
{
	public record UpdateLeaveTypeCommandRequest(string Name, int DefaultDays) : IRequest<Unit>;
}
