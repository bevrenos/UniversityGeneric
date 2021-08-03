using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityProject.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
