using Hospital.Data.Entities;
using Hospital.Data.Entities.HospitalData;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Data.Entities.PatientsData;
using Hospital.Data.Entities.Workers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hospital.Data.Contexts
{
	public class HospitalDbContext : DbContext
	{
		public HospitalDbContext(DbContextOptions options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Department> Departments { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Drug> Drugs { get; set; }
		public DbSet<DrugType> DrugTypes { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Order> Orders  { get; set; }
		public DbSet<OrderDetail> OrderDetails  { get; set; }
		public DbSet<Supplier> Suppliers  { get; set; }
		public DbSet<Examination> Examinations  { get; set; }
		public DbSet<MedicalFile> MedicalFiles  { get; set; }
		public DbSet<Patient>  Patients { get; set; }
		public DbSet<TreatmentPlan> TreatmentPlans  { get; set; }
		public DbSet<VitalSigns> VitalSigns  { get; set; }

		
	}
}
