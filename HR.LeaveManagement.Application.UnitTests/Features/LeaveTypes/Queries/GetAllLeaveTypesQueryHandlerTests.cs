using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Featues.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes
{
	public class GetAllLeaveTypesQueryHandlerTests
	{
		private readonly Mock<ILeaveTypeRepository> _mockRepo;
		private readonly IMapper _mapper;
		private readonly Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockAppLogger;

		public GetAllLeaveTypesQueryHandlerTests()
		{
			_mockRepo = MockLeaveTypeRepository.GetMockGetMockLeaveTypeRepository();

			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile<LeaveTypeProfile>();
			});

			_mapper = mapperConfig.CreateMapper();

			_mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
		}

		[Fact]
		public async Task GetLeaveTypeListTest()
		{
			var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object);

			var result = await handler.Handle(new GetAllLeaveTypesQueryRequest(), CancellationToken.None);

			result.ShouldBeOfType<List<LeaveTypeDto>>();

			result.Count.ShouldBe(3); // what we specified in MockLeaveTypeRepository.
		}
	}
}
