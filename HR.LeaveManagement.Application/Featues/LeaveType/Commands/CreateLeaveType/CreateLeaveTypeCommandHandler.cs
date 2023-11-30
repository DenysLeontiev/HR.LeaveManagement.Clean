using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommandRequest, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<int> Handle(CreateLeaveTypeCommandRequest request, CancellationToken cancellationToken)
		{
			var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

			await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

			return leaveTypeToCreate.Id;
		}
	} 
}
