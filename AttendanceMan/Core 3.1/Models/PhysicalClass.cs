using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  Core_3._1.Models
{

    [Table("PhysicalClass")]
    public partial class PhysicalClass
    {
        
        [Key]
       
        public long IdPhysicalClass { get; set; }

        [StringLength(50)]
        public string SubjectName { get; set; }
        public int NumberSession { get; set; }
        public string Description { get;set; }
        [ForeignKey("Student")]
        public long IdStudent { get; set; }
        [ForeignKey("Lecturer")]
        public long IdTeacher { get; set; }
        [ForeignKey("AttendanceEntry")]
        public long IdAttendanceEntry { get; set; }

        //  public virtual ICollection<AttendanceEntry> AttendanceEntries { get; set; }
        // public long IdStudent { get; set; }

        public virtual IEnumerable<Lecturer> Lecturers { get; set; }
        

        public virtual IEnumerable<Student> Students { get; set; }
        
        
       
        public IEnumerable<AttendanceEntry> attendanceEntry { get; set; }
        


    }
}
