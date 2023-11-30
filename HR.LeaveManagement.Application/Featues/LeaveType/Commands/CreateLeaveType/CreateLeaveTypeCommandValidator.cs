﻿using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Featues.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommandRequest>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
		{
			RuleFor(p => p.Name)
			.NotEmpty().WithMessage("{PropertyName} is required")
			.NotNull()
			.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(p => p.DefaultDays)
				.GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
				.LessThan(1).WithMessage("{PropertyName} cannot be less than 1");

			RuleFor(q => q)
				.MustAsync(LeaveTypeNameUnique)
				.WithMessage("Leave type already exists");

			_leaveTypeRepository = leaveTypeRepository;
		}

		private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommandRequest command, CancellationToken token)
		{
			return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
		}
	}
}
