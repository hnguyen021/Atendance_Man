using Core_3._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_3._1.ViewModel
{
    public class AttendanceCheckViewModel
    {
        
        public  IEnumerable<Student> Students { get; set; }
        public  PhysicalClass PhysicalClass { get; set; }
        public  IEnumerable<AttendanceEntry> AttendanceEntry { get; set; }
        public string IdTeacher { get; set; }
        public DateTime DateCheck { get; set; }

        public bool CheckAttendance { get; set; }

        public  Student Student { get; set; }

    }
}
