public class AdminDashboardViewModel
{
    public int SeminarCount { get; set; }
    public int TechnicalStaffCount { get; set; }
    public int NonTechnicalStaffCount { get; set; }
    public int TotalStaffCount { get; set; }

    public string SelectedAttendanceFilter { get; set; }
    public string SelectedFeedbackFilter { get; set; }
}
