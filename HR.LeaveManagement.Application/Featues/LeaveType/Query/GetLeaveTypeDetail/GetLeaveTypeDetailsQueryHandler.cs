using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail
{
	public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQueryRequest, LeaveTypeDetailsDto>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			_mapper = mapper;
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQueryRequest request, CancellationToken cancellationToken)
		{
			var leaveTypeDetails = await _leaveTypeRepository.GetByIdAsync(request.Id);

			var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypeDetails);

			return data;
		}
	}
}
