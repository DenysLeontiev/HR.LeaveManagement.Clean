using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
	public class MockLeaveTypeRepository
	{
		public static Mock<ILeaveTypeRepository> GetMockGetMockLeaveTypeRepository()
		{
			var leaveTypes = new List<LeaveType>
			{
				new LeaveType{ Id = 1, Name = "Sick", DefaultDays = 15},
				new LeaveType{ Id = 2, Name = "Vacation", DefaultDays = 10},
				new LeaveType{ Id = 3, Name = "Wedding", DefaultDays = 30},
			};

			var mock = new Mock<ILeaveTypeRepository>();

			mock.Setup(x => x.GetAllAsync()).ReturnsAsync(leaveTypes);

			mock.Setup(x => x.GetByIdAsync(1));

			mock.Setup(x => x.CreateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
			{
				leaveTypes.Add(leaveType);
				return Task.CompletedTask;
			});

			return mock;
		}
	}
}
