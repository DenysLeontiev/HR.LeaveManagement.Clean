using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.UpdateLeaveType
{
	public record UpdateLeaveTypeCommandRequest(int id,string Name, int DefaultDays) : IRequest<Unit>;
}
