using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.DeleteLeaveAllocation
{
	public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommandRequest, Unit>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public DeleteLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveAllocationRepository = leaveTypeRepository;
		}

		public async Task<Unit> Handle(DeleteLeaveAllocationCommandRequest request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);
			await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

			return Unit.Value;
		}
	}
}
