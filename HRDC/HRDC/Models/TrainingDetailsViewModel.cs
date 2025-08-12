namespace HRDC.Models
{
    public class TrainingDetailsViewModel
    {
        public string Title { get; set; }
        public string Trainer { get; set; }
        public string DateRange { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }

        // For user expectation input
        public string Expectations { get; set; }
    }
}
