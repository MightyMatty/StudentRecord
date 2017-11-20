
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObject
{
    public class Student
    {
        public Student(int number, string first, string last, DateTime dob,String grade)
        {
            Number = number;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            Grade = grade;
        }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get;private set; }
        public string Grade { get; set; }



    }
}
