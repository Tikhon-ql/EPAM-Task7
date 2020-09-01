using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Models
{
    public class Gender
    {
        public int Id { get; private set; }
        public string GenderName { get; set; }

        public Gender(int id, string genderName)
        {
            Id = id;
            GenderName = genderName;
        }
    }
}
