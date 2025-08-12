using HRDC.Models;
using System.Collections.Generic;

namespace HRDC.Models
{
    public class MarksEntryViewModel
    {
        public string SelectedTraining { get; set; }
        public int? OutOfMarks { get; set; }
        public List<string> Trainings { get; set; } = new();
        public List<EmployeeMarks> Employees { get; set; } = new();
        public string Message { get; set; }
    }
}
