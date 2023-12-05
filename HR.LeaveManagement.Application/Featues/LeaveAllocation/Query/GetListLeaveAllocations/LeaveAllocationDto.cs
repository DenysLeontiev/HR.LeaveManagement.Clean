using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetListLeaveAllocations
{
    public class LeaveAllocationDto
    {
		public int Id { get; set; }
		public int NumberOfDays { get; set; }
		public LeaveTypeDto LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
