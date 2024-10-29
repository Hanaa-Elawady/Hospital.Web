using Hospital.Data.Entities.Enums;
using Hospital.Data.Entities.Workers;

namespace Hospital.Data.Entities.PatientsData
{
    public class Examination
    {
        public Guid Id { get; set; }
		public DateTime ExaminationDate { get; set; }
		public Examinations ExaminationType { get; set; }
		public string Findings { get; set; }
		public string Recommendations { get; set; }
		public long DoctorId { get; set; }
		public Doctor Doctor { get; set; }
	}
}