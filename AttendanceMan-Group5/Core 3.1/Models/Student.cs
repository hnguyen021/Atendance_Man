using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  Core_3._1.Models
{

    [Table("Student")]
    public partial class Student
    {
        
      

        [Key]
        
        public long IdStudent { get; set; }

        [StringLength(50)]
        public string NameStudent { get; set; }
        public int Score { get; set; }
        [ForeignKey("PhysicalClass")]
        public long IdPhysicalClass { get; set; }
        [ForeignKey("AttendanceEntry")]
        public long IdAttendanceEntry { get; set; }


        public virtual IEnumerable<AttendanceEntry> AttendanceEntries { get; set; }

       public virtual IEnumerable<PhysicalClass> PhysicalClass { get; set; }
    }
}
