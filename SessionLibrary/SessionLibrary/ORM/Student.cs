
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MidleName { get; set; }
        public int GroupId { get; private set; }
        public int GenderId { get; private set; }

        public Student(int id, string name, string surname, string midleName, int group, int gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MidleName = midleName;
            GroupId = group;
            GenderId = gender;
        }
    }
}
