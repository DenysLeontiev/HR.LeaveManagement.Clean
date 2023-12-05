using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Commands.CancelLeaveRequest
{
	public class CancelLeaveRequestCommandRequest : IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
