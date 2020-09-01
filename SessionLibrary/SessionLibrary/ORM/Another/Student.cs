
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    /// <summary>
    /// Student's class
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Student's name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Student's surname property
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Student's midle name property
        /// </summary>
        public string MidleName { get; set; }
        /// <summary>
        /// Group's id property
        /// </summary>
        public int GroupId { get; private set; }
        /// <summary>
        /// Gender's id property
        /// </summary>
        public int GenderId { get; private set; }

        public Student()
        {

        }

        public Student(int id, string name, string surname, string midleName, int gender,int group)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MidleName = midleName;
            GroupId = group;
            GenderId = gender;
        }


        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   MidleName == student.MidleName &&
                   GroupId == student.GroupId &&
                   GenderId == student.GenderId;
        }

        public override int GetHashCode()
        {
            int hashCode = 829902979;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MidleName);
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + GenderId.GetHashCode();
            return hashCode;
        }
    }
}
