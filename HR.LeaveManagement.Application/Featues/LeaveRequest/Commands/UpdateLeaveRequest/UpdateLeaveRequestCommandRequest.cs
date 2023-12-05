using HR.LeaveManagement.Application.Featues.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Commands.UpdateLeaveRequest
{
	public class UpdateLeaveRequestCommandRequest : BaseLeaveRequest, IRequest<Unit>
	{
		public int Id { get; set; }
		public string RequestComments { get; set; } = string.Empty;
		public bool Cancelled { get; set; }
	}
}
