namespace ClassroomProject
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Classroom classroom = new Classroom(10);
            // Initialize entities
            Student student = new Student("Peter", "Parker", "Geometry");
            Student studentTwo = new Student("Sarah", "Smith", "Algebra");
            Student studentThree = new Student("Sam", "Winchester", "Algebra");
            Student studentFour = new Student("Dean", "Winchester", "Music");


            classroom.RegisterStudent(student);
            classroom.RegisterStudent(studentTwo);
            classroom.RegisterStudent(studentThree);
            classroom.RegisterStudent(studentFour);


            string dismissed = classroom.DismissStudent("Peter", "Parker");
            Console.WriteLine(dismissed); // Dismissed student Peter Parker
            string dismissedTwo = classroom.DismissStudent("Ellie", "Goulding");
            Console.WriteLine(dismissedTwo); // Student not found

            // Subject info
            string subjectInfo = classroom.GetSubjectInfo("Algebra");
            Console.WriteLine(subjectInfo);
            // Subject: Algebra
            // Students:
            // Sarah Smith
            // Sam Winchester
            string anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo); // No students enrolled for the subject
                                            // Get Student
            Console.WriteLine(classroom.GetStudent("Dean", "Winchester"));
            // Student: First Name = Dean, Last Name = Winchester, Subject = Music


        }
    }
}