using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HR.LeaveManagement.Application.IntegrationTests
{
	public class HrDatabaseContextTests
	{
		private HrDatabaseContext _hrDatabaseContext;

		public HrDatabaseContextTests()
		{
			//here, we mock our database (we installed EFCore.InMemory for integration tests)
			var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

			_hrDatabaseContext = new HrDatabaseContext(dbOptions);
		}

		[Fact]
		public async void Save_SetDateCreatedValue()
		{
			// Arrange
			var leaveType = new LeaveType
			{
				Id = 1,
				DefaultDays = 10,
				Name = "Test Vacation"
			};

			// Act
			await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
			await _hrDatabaseContext.SaveChangesAsync();

			// Assert
			leaveType.DateCreated.ShouldNotBeNull();
		}

		[Fact]
		public async void Save_SetDateModifiedValue()
		{
			// Arrange
			var leaveType = new LeaveType
			{
				Id = 1,
				DefaultDays = 10,
				Name = "Test Vacation"
			};

			// Act
			await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
			await _hrDatabaseContext.SaveChangesAsync();

			// Assert
			leaveType.DateModified.ShouldNotBeNull();
		}
	}
}
