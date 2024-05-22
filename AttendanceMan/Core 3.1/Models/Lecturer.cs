using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_3._1.Models
{
   
        [Table("Lecturer")]
        public partial class Lecturer
        {
            [Key]
            public long IdTeacher { get; set; }

            [StringLength(50)]
            public string NameTeacher { get; set; }
            public string MailTeacher { get;set; }

            [StringLength(50)]
            public string TeacherAccount { get; set; }

            [StringLength(50)]
            public string Password { get; set; }
            [ForeignKey("PhysicalClass")]
            public long IdPhysicalClass { get; set; }
            public virtual IEnumerable<PhysicalClass> PhysicalClass { get; set; }

        
    }
}
