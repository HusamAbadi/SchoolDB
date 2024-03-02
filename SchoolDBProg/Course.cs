using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolDBProg
{
    internal class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;

        //navigation property
        public ICollection<Student> Students { get; set; } = null!;
    }
}

