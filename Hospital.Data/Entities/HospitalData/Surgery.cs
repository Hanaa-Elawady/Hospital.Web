using Hospital.Data.Entities.PatientsData;
using Hospital.Data.Entities.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities.HospitalData
{
    public class Surgery
    {
        public int SurgeryId { get; set; }
        public Patient patient { get; set; }
        public long PatientId { get; set; } // Foreign key to Patient
        public Doctor Doctor { get; set; }
        public long DotorId { get; set; } // Foreign key to Doctor
        public DateTime SurgeryDate { get; set; }
        public string SurgeryType { get; set; }
        public string Notes { get; set; }
    }

}
