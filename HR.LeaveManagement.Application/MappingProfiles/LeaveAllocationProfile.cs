using AutoMapper;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetListLeaveAllocations;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
	public class LeaveAllocationProfile : Profile
	{
		public LeaveAllocationProfile()
		{
			CreateMap<UpdateLeaveAllocationQueryRequest, LeaveAllocation>().ReverseMap();
			CreateMap<LeaveAllocation, GetListLeaveAllocationsQueryRequest>().ReverseMap();
			CreateMap<LeaveAllocation, GetLeaveAllocationDetailsQueryRequest>().ReverseMap();
			CreateMap<CreateLeaveAllocationCommandRequest, LeaveAllocation>();
		}
	}
}
