using HR.LeaveManagement.Application.Featues.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Commands.CreateLeaveRequest
{
	public class CreateLeaveRequestCommandRequest : BaseLeaveRequest, IRequest<Unit>
	{
		public string RequestComments { get; set; } = string.Empty;
	}
}
