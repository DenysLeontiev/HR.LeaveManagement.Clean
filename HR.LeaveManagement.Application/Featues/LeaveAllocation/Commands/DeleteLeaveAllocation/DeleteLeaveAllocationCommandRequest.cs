using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.DeleteLeaveAllocation
{
	public record DeleteLeaveAllocationCommandRequest(int Id) : IRequest<Unit>;
}
