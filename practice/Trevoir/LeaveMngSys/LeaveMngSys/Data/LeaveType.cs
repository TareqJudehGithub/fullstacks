using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveMngSys.Data
{
    public class LeaveType
    {
        #region Properties

        public int Id { get; set; }
        [Column("Name", TypeName = "NVARCHAR(150)")]
        public string Name { get; set; }
        [Display(Name = "No. of Days")]
        public int NumberOfDays { get; set; }


        #endregion
    }
}
