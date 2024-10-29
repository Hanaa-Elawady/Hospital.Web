using Hospital.Data.Entities.PatientsData;
using Hospital.Data.Entities.Workers;

namespace Hospital.Data.Entities.HospitalData
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> doctors { get; set; }
        public ICollection<Nurse> nurses { get; set; }
        public ICollection<Patient> patients { get; set; }
        public int totalNumberOfBeds { get; set; }
        public int occupiedBeds { get; set; }
        public int AvailbleNumberOfBeds { get; set;}
    }
}
