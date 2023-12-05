using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetLeaveAllocationDetails
{
	public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQueryRequest, LeaveAllocationDetailsDto>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQueryRequest request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

			if(leaveAllocation is null) 
			{
				throw new NotFoundException(nameof(LeaveType), request.Id);
			}

			var mappedLeaveAllocation = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);

			return mappedLeaveAllocation;
		}
	}
}
