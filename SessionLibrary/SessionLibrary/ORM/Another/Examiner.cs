using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    public class Examiner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MidleName { get; set; }

        public Examiner(int id, string name, string surname, string midleName)
        {
            Id = id;
            Name = name;
            Surname = surname;
            MidleName = midleName;
        }
    }
}
