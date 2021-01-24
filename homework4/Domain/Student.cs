using System;
using System.Collections.Generic;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
    
}