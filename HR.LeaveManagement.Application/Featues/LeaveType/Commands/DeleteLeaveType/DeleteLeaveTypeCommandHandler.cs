using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
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

			if(leaveTypeToDelete is null)
			{
				throw new NotFoundException(nameof(LeaveType), request.Id);
			}

			await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

			return Unit.Value;
		}
	}
}
