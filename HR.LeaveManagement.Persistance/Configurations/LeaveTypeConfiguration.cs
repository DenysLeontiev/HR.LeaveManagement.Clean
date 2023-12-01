﻿using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistance.Configurations
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			builder.HasData(new LeaveType
			{
				Id = 1,
				Name = "Vacation",
				DefaultDays = 10,
				DateCreated = DateTime.Now,
				DateModified = DateTime.Now,
			});
		}
	}
}
