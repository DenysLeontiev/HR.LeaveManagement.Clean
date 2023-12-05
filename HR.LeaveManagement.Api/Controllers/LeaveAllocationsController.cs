using HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Featues.LeaveAllocation.Query.GetListLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveAllocationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveAllocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
		{
			var leaveAllocations = await _mediator.Send(new GetListLeaveAllocationsQueryRequest());	
			return Ok(leaveAllocations);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveAllocationDetailsDto>> GetById(int id)
		{
			var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQueryRequest(id));
			return leaveAllocation;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Post(CreateLeaveAllocationCommandRequest createLeaveAllocation)
		{
			var response = await _mediator.Send(createLeaveAllocation);
			return CreatedAtAction(nameof(Get), new { Id = response });
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put(UpdateLeaveAllocationQueryRequest updateLeaveAllocation)
		{
			await _mediator.Send(updateLeaveAllocation);
			return NoContent();
		}
	}
}
