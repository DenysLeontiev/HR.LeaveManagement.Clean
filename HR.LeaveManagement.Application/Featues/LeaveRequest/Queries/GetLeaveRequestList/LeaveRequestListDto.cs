using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Queries.GetLeaveRequestList
{
	public class LeaveRequestListDto
	{
		public string RequestingEmployeeId { get; set; }
		public LeaveTypeDto LeaveType { get; set; }
		public DateTime DateRequested { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool? Approved { get; set; }
	}
}
