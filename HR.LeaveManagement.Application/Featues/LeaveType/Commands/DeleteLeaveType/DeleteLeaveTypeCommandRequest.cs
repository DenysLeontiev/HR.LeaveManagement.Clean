using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.DeleteLeaveType
{
	public record DeleteLeaveTypeCommandRequest(int Id) : IRequest<Unit>;
}
