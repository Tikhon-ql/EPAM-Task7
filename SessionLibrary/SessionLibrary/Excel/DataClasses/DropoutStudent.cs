using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.Excel.DataClasses
{
    /// <summary>
    /// Dropout student's class
    /// </summary>
    public class DropoutStudent
    {
        /// <summary>
        /// Dropout student's name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Dropout student's surname property
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Dropout student's midle name property
        /// </summary>
        public string MidleName { get; set; }

        public DropoutStudent(string name, string surname, string midleName)
        {
            Name = name;
            Surname = surname;
            MidleName = midleName;
        }
    }
}
