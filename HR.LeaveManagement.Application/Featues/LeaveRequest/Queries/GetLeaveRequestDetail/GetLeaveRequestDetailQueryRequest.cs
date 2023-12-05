using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveRequest.Queries.GetLeaveRequestDetail
{
	public class GetLeaveRequestDetailQueryRequest : IRequest<LeaveRequestDetailsDto>
	{
		public int Id { get; set; }
	}
}
