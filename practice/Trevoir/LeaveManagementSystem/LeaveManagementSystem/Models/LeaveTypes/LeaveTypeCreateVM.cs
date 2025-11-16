using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeCreateVM : BaseLeaveTypeVM
    {
        #region Properties        
        [Display(Name = "Leave Type")]
        [Column(TypeName = "NVARCHAR(150)")]
        [Required]
        [Length(4, 30, ErrorMessage = "Leave Type must between {1} and {2} characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Range(1, 21, ErrorMessage = "{0} should be between {1} and {2}!")]
        [Display(Name = "No. of Days")]
        public int NumberOfDays { get; set; }
        #endregion
    }
}
