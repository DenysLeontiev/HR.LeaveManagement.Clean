using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.UpdateLeaveType
{
    public class UpdateLeaveAllocationQueryHandler : IRequestHandler<UpdateLeaveAllocationQueryRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationQueryRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);

            return Unit.Value;
        }
    }
}
