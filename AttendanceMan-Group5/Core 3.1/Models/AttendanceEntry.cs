using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  Core_3._1.Models
{

    [Table("AttendanceEntry")]
    public partial class AttendanceEntry
    {
        public AttendanceEntry()
        {
            DateCheck = DateTime.Now;
        }
        [Key]
        public long IdAttendanceEntry { get; set; }

 

        public DateTime DateCheck { get; set; }

        public bool CheckAttendance { get; set; }
        
        
        [ForeignKey("PhysicalClass")]
        public long IdPhysicalClass { get; set; }
        public virtual IEnumerable<PhysicalClass> PhysicalClass { get; set; }
        [ForeignKey("Student")]
        public long IdStudent { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }

    }
}
