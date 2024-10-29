using Hospital.Data.Entities.PatientsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Configurations
{
	internal class PatientConfigurations : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.HasMany(patient => patient.MedicalFiles).WithOne().OnDelete(DeleteBehavior.NoAction);

		}
	}
}
