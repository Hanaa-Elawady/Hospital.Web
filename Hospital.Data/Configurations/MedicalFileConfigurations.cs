using Hospital.Data.Entities.PatientsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Hospital.Data.Configurations
{
	internal class MedicalFileConfigurations : IEntityTypeConfiguration<MedicalFile>
	{
		public void Configure(EntityTypeBuilder<MedicalFile> builder)
		{
			builder.HasMany(file => file.examinations).WithOne().OnDelete(DeleteBehavior.NoAction);

		}
	}
}
