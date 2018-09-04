using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            int select = 1;

            Program program = new Program();
            
             
                Console.WriteLine("Enter \n1 : Add New Course : \n"
                    +
                    "2 : Add new Student :\n" +
                    "3 : DeleteStudent :\n" +
                    "4 : Update New Course :\n" +
                    "5 : View Student :\n" +
                    "6 : Exit ");


                select = Convert.ToInt32(Console.ReadLine());
            
           
         
            switch (select)
            {
                case 1:
                    program.AddCourse();
                   

                    break;
                case 2:
                    program.AddStudent();
                    break;
                case 3:
                    program.DeleteStudent();
                    break;
                case 4:
                    program.UpdateStudent();
                    Console.ReadKey();
                    break;
                
                case 5:
                    program.ViewStudentRecord();
                    break;

                default:
                    Console.WriteLine("Please Enter no between 1 to 5");
                    Console.ReadKey();
                    break;
                  
            }

            


        }

        private void AddCourse()
        {
            using (Model1 model1 = new Model1())
            {
                Console.Write("Enter Course Name :  ");
                string courseName = Console.ReadLine();
                Console.Write("Enter course Session: ");
                string courseSession = Console.ReadLine();
                Course course = new Course()
                {
                    CourseName = courseName,
                    CourseSession = courseSession,
                };
                model1.Courses.Add(course);
                model1.SaveChanges();

                Console.ReadKey();
            }

        }
        private void AddStudent()
        {
            using (Model1 model1 = new Model1())
            {
                Console.Write("Enter Student Name :  ");
                string studentName = Console.ReadLine();
                Console.Write("Enter Student Class:");
                string studentClass = Console.ReadLine();



                Console.WriteLine("Enter Your Choice : ");
                foreach (var item in model1.Courses)
                {
                    Console.WriteLine(item.CourseName + "   For   " + item.CourseID);

                }
                int courseID = Convert.ToInt32(Console.ReadLine());

                Student student = new Student()
                {
                    StudentName = studentName,
                    StudentClass = studentClass,
                    CourseID = courseID

                };
                model1.Students.Add(student);
                model1.SaveChanges();
            }
        }
        private void DeleteStudent()
        {
            using (Model1 model1 = new Model1())
            {
                Console.Write("Enter Student ID  :  ");
                int studentID = Convert.ToInt32(Console.ReadLine());
                Student student = model1.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
                if (student != null)
                    model1.Students.Remove(student);
                else
                    Console.WriteLine("Student ID not Found ");
                model1.SaveChanges();
            }
        }


        private void UpdateStudent()
        {
            using (Model1 model1 = new Model1())
            {
                Console.Write("Enter Student ID  :  ");
                int studentID = Convert.ToInt32(Console.ReadLine());
                Student student = model1.Students.Where(x => x.StudentID == studentID).FirstOrDefault();
                if (student != null)
                {
                    Console.Write("Enter Student Name :  ");
                    string studentName = Console.ReadLine();
                    Console.Write("Enter Student Class");
                    string studentClass = Console.ReadLine();



                    Console.WriteLine("Enter Your Choice : ");
                    foreach (var item in model1.Courses)
                    {
                        Console.WriteLine(item.CourseName + "   For   " + item.CourseID);

                    }
                    int courseID = Convert.ToInt32(Console.ReadLine());

                    student.StudentName = studentName;
                    student.StudentClass = studentClass;
                    student.CourseID = courseID;

                }

                else
                    Console.WriteLine("Student ID not Found ");
                model1.SaveChanges();
            }

        }

        private void ViewStudentRecord()
        {
            using (Model1 model1 = new Model1())
            {
                foreach (var item in model1.Students)
                {
                    Console.WriteLine(item.StudentID + "   " + item.StudentName + "    " + item.StudentClass + "  " + item.CourseID);
                }
            }
            Console.ReadKey();
        }

    }
  
}
