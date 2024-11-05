using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Data.Entities.Workers;

namespace Hospital.Data.Entities.PatientsData
{
    public class TreatmentPlan
    {
        public Guid Id { get; set; }
        public string Diagnosis { get; set; }
        public List<Drug> Medications { get; set; }
        public List<string> Procedures { get; set; }
        public DateTime FollowUpDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime ActualEndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid ReportId { get; set; }
    }
}