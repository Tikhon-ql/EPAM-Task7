
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    /// <summary>
    /// Student's class
    /// </summary>
    [Table(Name = "Student")]
    public class Student
    {
        /// <summary>
        /// Student's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        /// <summary>
        /// Student's name property
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Student's surname property
        /// </summary>
        [Column(Name = "Surname")]
        public string Surname { get; set; }
        /// <summary>
        /// Student's midle name property
        /// </summary>
        [Column(Name = "MidleName")]
        public string MidleName { get; set; }
        /// <summary>
        /// Group's id property
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; private set; }
        /// <summary>
        /// Gender's id property
        /// </summary>
        [Column(Name = "GenderId")]
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
    }
}
