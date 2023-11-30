using AutoMapper;
using HR.LeaveManagement.Application.Featues.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
	public class LeaveTypeProfile : Profile
	{
		public LeaveTypeProfile()
		{
			CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
			CreateMap<LeaveType, LeaveTypeDetailsDto>();
			CreateMap<CreateLeaveTypeCommandRequest, LeaveType>();
			CreateMap<UpdateLeaveTypeCommandRequest, LeaveType>();
		}
	}
}
