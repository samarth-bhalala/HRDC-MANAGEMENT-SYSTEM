public class TrainingSession
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string TrainerName { get; set; } = "";
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public TimeSpan TimeFrom { get; set; }
    public TimeSpan TimeTo { get; set; }
    public string Venue { get; set; } = "";
    public string Description { get; set; } = "";
    public string Status { get; set; } = "";
}
