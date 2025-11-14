using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        #region Properties
        [DisplayName("Leave Type")]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Name { get; set; }

        [DisplayName("No. of Days")]
        public int NumberOfDays { get; set; }
        #endregion
    }
}
