using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM
    {
        public int Id { get; set; }
        [DisplayName("Leave Type")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "No. of Days")]
        public int NumberOfDays { get; set; }
    }
}
