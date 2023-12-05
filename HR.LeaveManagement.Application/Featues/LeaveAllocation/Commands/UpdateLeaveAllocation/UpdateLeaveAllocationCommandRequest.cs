using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.UpdateLeaveType
{
    public record UpdateLeaveAllocationQueryRequest(int NumberOfDays, int Period) : IRequest<Unit>;
}
