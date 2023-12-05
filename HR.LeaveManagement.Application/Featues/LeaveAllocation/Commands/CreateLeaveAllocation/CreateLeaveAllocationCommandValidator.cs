using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.CreateLeaveAllocation
{
	public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommandRequest>
	{
		public CreateLeaveAllocationCommandValidator()
		{

		}
	}
}
