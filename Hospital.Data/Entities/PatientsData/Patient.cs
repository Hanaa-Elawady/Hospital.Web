using Hospital.Data.Entities.Enums;

namespace Hospital.Data.Entities.PatientsData
{
    public class Patient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string JobTitle { get; set; }
        public string InsuranceNumber { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int Age { get; set; }
        public BloodType BloodType { get; set; }

        public List<ChronicDiseases> chronicDiseases { get; set; }
        public ICollection<MedicalFile> MedicalFiles { get; set; } = new List<MedicalFile>();

    }
}
