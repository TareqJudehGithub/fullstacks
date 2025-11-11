using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Data
{
    [Table("LeaveType", Schema = "dbo")]
    public class LeaveType
    {
        #region Properties
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Name { get; set; }

        [Display(Name = "No. of Days")]
        public int NumberOfDays { get; set; }
        #endregion
    }
}
