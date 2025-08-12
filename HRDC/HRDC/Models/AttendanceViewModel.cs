using Microsoft.AspNetCore.Mvc.Rendering;

public class AttendanceViewModel
{
    public int SelectedTrainingSessionId { get; set; }
    public List<SelectListItem> TrainingSessions { get; set; } = new();
    public string SearchTerm { get; set; }

    public List<EmployeeAttendance> Employees { get; set; } = new();

    public class EmployeeAttendance
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool IsPresent { get; set; }
    }
}
