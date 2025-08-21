using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

public class EmployeeViewModel
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Designation { get; set; }
    public string EmployeeType { get; set; }
}
    
public class EmployeeListViewModel
{
    public List<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    public string SelectedType { get; set; }
    public List<SelectListItem> EmployeeTypes { get; set; } = new List<SelectListItem>();
}
