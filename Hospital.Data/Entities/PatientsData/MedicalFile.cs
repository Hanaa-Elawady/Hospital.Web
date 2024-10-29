using Hospital.Data.Entities.Workers;

namespace Hospital.Data.Entities.PatientsData
{
    public class MedicalFile
    {
        public Guid Id { get; set; }
        public DateTime EnterTime { get; set; } = DateTime.Now;
        public DateTime? OutTime { get; set; }
        public string initialDiagnosis { get; set; }

        public ICollection<Examination> examinations { get; set; } = new List<Examination>();
        public List<string> symptoms { get; set; } = new List<string>();


        public ICollection<VitalSigns> vitalSigns { get; set; }
        public ICollection<TreatmentPlan> treatmentPlans { get; set; }

        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
