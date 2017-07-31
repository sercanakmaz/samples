using System;
using System.Collections.Generic;
using System.Text;
using static System.String;
using static System.Linq.Enumerable;
using System.Collections;

namespace _60And70
{
    public class _60Samples
    {
        static void Process(string[] args)
        {
            Student first = new Student();

            try
            {
                first.ChangeName(string.Empty);
            }
            catch (Exception ex) when (ex.Message.Contains("newLastName"))
            {
                Console.WriteLine("hata:{0}", ex.Message);
            }

            Console.WriteLine(first?.FirstName);

            bool gender = first?.Gender ?? true;

            Console.WriteLine("Gender: {0}", gender);

            if (!IsNullOrEmpty(first.FirstName))
            {
                Console.WriteLine(first);
            }

            foreach (var item in first.Grades)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
    public class Student
    {
        private Dictionary<int, string> webErrors = new Dictionary<int, string>
        {
            [404] = "Page not Found",
            [302] = "Page moved, but left a forwarding address.",
            [500] = "The web server can't come out to play today."
        };
        public string FirstName { get; } = "Sercan";
        public string LastName { get; } = "Akmaz";
        public bool? Gender { get; set; }
        public ICollection<double> Grades { get; } = new List<double>() { 45 };

        public Student()
        {

        }

        public Student(string firstName, string lastName)
        {

        }

        public string GetGradePointPercentage() => $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";
        public string GetAllGrades() => $@"All Grades: {Grades.OrderByDescending(g => g).Select(s => s.ToString("F2")).Aggregate((partial, element) => $"{partial}, {element}")}";

        public void ChangeName(string newLastName)
        {
            if (IsNullOrWhiteSpace(newLastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(newLastName));

            // Generates CS 0200: Property or indexer cannot be assigned to -- it is read only
            //LastName = newLastName;
        }
        public override string ToString() => $"{LastName}, {FirstName}";
    }
    public class Enrollment : IEnumerable<Student>
    {
        private List<Student> allStudents = new List<Student>();

        public void Enroll(Student s)
        {
            allStudents.Add(s);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
        }
    }
    public static class StudentExtensions
    {
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
    }
    public class ClassList
    {
        public Enrollment CreateEnrollment()
        {
            var classList = new Enrollment()
        {
            new Student("Lessie", "Crosby"),
            new Student("Vicki", "Petty"),
            new Student("Ofelia", "Hobbs"),
            new Student("Leah", "Kinney"),
            new Student("Alton", "Stoker"),
            new Student("Luella", "Ferrell"),
            new Student("Marcy", "Riggs"),
            new Student("Ida", "Bean"),
            new Student("Ollie", "Cottle"),
            new Student("Tommy", "Broadnax"),
            new Student("Jody", "Yates"),
            new Student("Marguerite", "Dawson"),
            new Student("Francisca", "Barnett"),
            new Student("Arlene", "Velasquez"),
            new Student("Jodi", "Green"),
            new Student("Fran", "Mosley"),
            new Student("Taylor", "Nesmith"),
            new Student("Ernesto", "Greathouse"),
            new Student("Margret", "Albert"),
            new Student("Pansy", "House"),
            new Student("Sharon", "Byrd"),
            new Student("Keith", "Roldan"),
            new Student("Martha", "Miranda"),
            new Student("Kari", "Campos"),
            new Student("Muriel", "Middleton"),
            new Student("Georgette", "Jarvis"),
            new Student("Pam", "Boyle"),
            new Student("Deena", "Travis"),
            new Student("Cary", "Totten"),
            new Student("Althea", "Goodwin")
        };
            return classList;
        }
    }
}
