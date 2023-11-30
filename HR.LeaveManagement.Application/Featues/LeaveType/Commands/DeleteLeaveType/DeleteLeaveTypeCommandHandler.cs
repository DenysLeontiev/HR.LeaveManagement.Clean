using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommandRequest, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
		{
			_leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommandRequest request, CancellationToken cancellationToken)
		{
			var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

			// Verify record exists

			await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

			return Unit.Value;
		}
	}
}
