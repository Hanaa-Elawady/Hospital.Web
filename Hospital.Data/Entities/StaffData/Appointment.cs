namespace Hospital.Data.Entities.Workers
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}