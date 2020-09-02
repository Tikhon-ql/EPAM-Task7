using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace SessionLibrary.ORM.Another
{
    /// <summary>
    /// Subject's class
    /// </summary>
    [Table(Name = "Subject")]
    public class Subject
    {
        /// <summary>
        /// Subject's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        /// <summary>
        /// Subject's name property
        /// </summary>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        public Subject(int id, string subjectName)
        {
            Id = id;
            SubjectName = subjectName;
        }
    }
}