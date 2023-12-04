using HR.LeaveManagement.Application.Featues.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveTypesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveTypesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<LeaveTypeDto>> Get()
		{
			var leaveTypes = await _mediator.Send(new GetAllLeaveTypesQueryRequest());
			return leaveTypes;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveTypeDetailsDto>> GetById(int id)
		{
			var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQueryRequest(id));
			return Ok(leaveType);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveTypeCommandRequest createLeaveType)
		{
			var response = await _mediator.Send(createLeaveType);
			return CreatedAtAction(nameof(Get), new { id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put(UpdateLeaveTypeCommandRequest updateLeaveType)
		{
			await _mediator.Send(updateLeaveType);
			return NoContent();	
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteLeaveTypeCommandRequest(id));
			return NoContent();
		}
	}
}
