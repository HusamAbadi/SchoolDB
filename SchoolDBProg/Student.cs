using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolDBProg
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; } = null!;

        //navigation property
        public ICollection<Course> Courses { get; set; } = null!;
    }
}
