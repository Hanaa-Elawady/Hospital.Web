namespace Hospital.Data.Entities.PatientsData
{
    public class VitalSigns
    {
        public Guid Id { get; set; }
        public Guid MedicalFileId { get; set; }
        public MedicalFile MedicalFile { get; set; }
        public DateTime CheckTime { get; set; }
        public double BodyTemperature { get; set; }
        public int HeartRate { get; set; }
        public int RespiratoryRate { get; set; }
        public int SystolicBloodPressure { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public int OxygenSaturation { get; set; }
    }
}