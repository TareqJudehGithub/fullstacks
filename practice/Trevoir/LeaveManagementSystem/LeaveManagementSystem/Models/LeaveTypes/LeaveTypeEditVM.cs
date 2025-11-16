using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {

        #region Properties        
        [Required]
        [Display(Name = "Leave Type")]
        [Length(4, 30, ErrorMessage = "Leave Type must between {1} and {2} characters long.")]
        //[MaxLength(length: 30, ErrorMessage = "{0} length cannot exceed {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Range(1, 21, ErrorMessage = "{0} should be between {1} and {2}!")]
        [Display(Name = "No. of Days")]
        public int NumberOfDays { get; set; }
        #endregion
    }
}
