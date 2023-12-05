using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommandRequest, int>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
		{
			var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

			// Get Employees

			//Get Period

			//Assign Allocations
			var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);
			await _leaveAllocationRepository.CreateAsync(leaveAllocation);

			return leaveAllocation.Id;
		}
	}
}
