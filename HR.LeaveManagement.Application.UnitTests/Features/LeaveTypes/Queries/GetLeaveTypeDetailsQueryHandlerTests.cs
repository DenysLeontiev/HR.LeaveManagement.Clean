using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetLeaveTypeDetail;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes
{
	public class GetLeaveTypeDetailsQueryHandlerTests
	{
		private readonly Mock<ILeaveTypeRepository> _mockRepo;
		private readonly IMapper _mapper;
		private readonly Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>> _mockAppLogger;

		public GetLeaveTypeDetailsQueryHandlerTests()
		{
			_mockRepo = MockLeaveTypeRepository.GetMockGetMockLeaveTypeRepository();

			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile<LeaveTypeProfile>();
			});

			_mapper = mapperConfig.CreateMapper();

			_mockAppLogger = new Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>>();
		}

		[Fact]
		public async Task GetLeaveTypeDetailsTest()
		{
			var handler = new GetLeaveTypeDetailsQueryHandler(_mapper, _mockRepo.Object);

			var result = await handler.Handle(new GetLeaveTypeDetailsQueryRequest(1), CancellationToken.None);

			result.ShouldBeOfType<LeaveTypeDetailsDto>().ShouldBeNull();

		}
	}
}
