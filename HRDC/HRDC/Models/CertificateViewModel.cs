namespace HRDC.Models
{
    public class CertificateViewModel
    {
        public string TrainingName { get; set; }
        public DateTime Date { get; set; }
        public string CertificatePath { get; set; }

        public string SelectedTraining { get; set; }
        public List<string> Trainings { get; set; } = new();
        public List<Participant> Participants { get; set; } = new();
        public string StatusMessage { get; set; }
    }
}
