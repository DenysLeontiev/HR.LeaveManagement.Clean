using HR.LeaveManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagement.Domain
{
	public class LeaveRequest : BaseEntity
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public LeaveType? LeaveType { get; set; }
		public int LeaveTypeId { get; set; }

		public DateTime DateRequested { get; set; }
		public string? RequestComments { get; set; }

		public bool? Approved { get; set; }
		public bool Canceled { get; set; }

		public string RequestionEmployeeId { get; set; } = string.Empty;
	}
}
