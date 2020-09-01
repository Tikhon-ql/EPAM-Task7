using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace SessionLibrary.ORM.Another
{
    /// <summary>
    /// Subject's class
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Subject's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Subject's name property
        /// </summary>
        public string SubjectName { get; set; }

        public Subject(int id, string subjectName)
        {
            Id = id;
            SubjectName = subjectName;
        }
    }
}