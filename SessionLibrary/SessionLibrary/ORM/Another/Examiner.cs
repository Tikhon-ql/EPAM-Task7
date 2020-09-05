using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    [Table(Name = "Examiner")]
    public class Examiner
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "Surname")]
        public string Surname { get; set; }
        [Column(Name = "MidleName")]
        public string MidleName { get; set; }

        public Examiner(int id, string name, string surname, string midleName)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MidleName = midleName;
        }
        public Examiner()
        {

        }


    }
}
