using Hospital.Data.Entities.Enums;

namespace Hospital.Data.Entities.Workers
{
    public class WorkerBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int Age { get; set; }
        public decimal BaseSalary { get; set; }
        public int AnnualVacations { get; set; }
        public int AvailableAnnualVacations { get; set; }
        public long VisaNumber { get; set; }

    }
}
