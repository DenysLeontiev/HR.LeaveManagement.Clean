using AutoMapper;
using HR.LeaveManagement.Application.Featues.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Featues.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Featues.LeaveRequest.Queries.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.Featues.LeaveRequest.Queries.GetLeaveRequestList;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
	public class LeaveRequestProfile : Profile
	{
		public LeaveRequestProfile()
		{
			CreateMap<LeaveRequestListDto, LeaveRequest>().ReverseMap();
			CreateMap<LeaveRequestDetailsDto, LeaveRequest>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestDetailsDto>();
			CreateMap<CreateLeaveRequestCommandRequest, LeaveRequest>();
			CreateMap<UpdateLeaveRequestCommandHandler, LeaveRequest>();
		}
	}
}
