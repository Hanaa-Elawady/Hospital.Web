using Hospital.Data.Entities.HospitalData;

namespace Hospital.Data.Entities.Workers
{
    public class Doctor : WorkerBaseEntity
    {
        public string specialization { get; set; }
        public Guid departmentId { get; set; }
        public Department department { get; set; }
        public List<Appointment> appointments { get; set; }
    }
}
