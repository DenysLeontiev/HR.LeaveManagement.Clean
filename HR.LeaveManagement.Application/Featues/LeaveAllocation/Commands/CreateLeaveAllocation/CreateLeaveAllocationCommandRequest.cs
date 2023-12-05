using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public record CreateLeaveAllocationCommandRequest(int LeaveTypeId) : IRequest<int>;
}
