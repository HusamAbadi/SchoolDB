using Microsoft.EntityFrameworkCore;

namespace SchoolDBProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Student list");
            using (var context = new SchoolDBContext())
            {
                var studList = from stud in context.Students
                               select stud;
                foreach (var item in studList)
                {
                    Console.WriteLine("\n" + item.StudentId + "\t" + item.Name);
                }
                Console.WriteLine("\nStudents and their Courses\n");
                var students = context.Students
                    .Include(s=>s.Courses)
                    .ToList().ToList();
                foreach (var student in students)
                {
                    Console.WriteLine("\n"+student.StudentId+ "\t" + student.Name);
                    foreach(var course in student.Courses)
                    {
                        Console.WriteLine("\t" + course.CourseName);
                    }
                }

            }
        }
    }
}