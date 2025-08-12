namespace HRDC.Models
{
    public class TrainingFeedbackViewModel
    {
        // Step 1 - Session Feedback
        public int SessionRelevance { get; set; }  // 1-5
        public int SessionOrganization { get; set; } // 1-5
        public string SessionComments { get; set; }

        // Step 2 - Trainer Feedback
        public int TrainerExpertise { get; set; }  // 1-5
        public int TrainerEngagement { get; set; } // 1-5
        public string TrainerComments { get; set; }
    }
}
