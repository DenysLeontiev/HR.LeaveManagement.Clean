using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetListLeaveAllocations
{
	public class GetListLeaveAllocationsQueryHandler : IRequestHandler<GetListLeaveAllocationsQueryRequest, List<LeaveAllocationDto>>
	{
		private readonly ILeaveAllocationRepository _leaveAllocation;
		private readonly IMapper _mapper;

		public GetListLeaveAllocationsQueryHandler(ILeaveAllocationRepository leaveAllocation, IMapper mapper)
		{
			_leaveAllocation = leaveAllocation;
			_mapper = mapper;
		}

		public async Task<List<LeaveAllocationDto>> Handle(GetListLeaveAllocationsQueryRequest request, CancellationToken cancellationToken)
		{
			var leaveTypes = await _leaveAllocation.GetAllLeaveAllocationsWithDetails();

			var mappedLeaveTypes = _mapper.Map<List<LeaveAllocationDto>>(leaveTypes);

			return mappedLeaveTypes;
		}
	}
}
