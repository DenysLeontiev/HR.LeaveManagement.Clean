using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes
{
	public class GetLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQueryRequest, List<LeaveTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypesQueryRequest request, CancellationToken cancellationToken)
		{
			//Query db
			var leaveTypes = await _leaveTypeRepository.GetAllAsync();
			//Convert objects to DTOs
			var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
			//Return DTO
			return data;
		}
	}
}
