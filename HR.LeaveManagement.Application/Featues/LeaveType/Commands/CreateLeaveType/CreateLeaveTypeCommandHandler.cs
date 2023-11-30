using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
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
			// Validate incoming data
			var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
				throw new BadRequestException("Invalid Leave type", validationResult);

			var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

			await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

			return leaveTypeToCreate.Id;
		}
	} 
}
