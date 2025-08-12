using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class EmployeeEditViewModel
{
    public int EmployeeId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Email { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    public List<SelectListItem> Departments { get; set; }

    [Required]
    public int DesignationId { get; set; }
    public List<SelectListItem> Designations { get; set; }

    [Required]
    public int EmployeeTypeId { get; set; }
    public List<SelectListItem> EmployeeTypes { get; set; }
}
