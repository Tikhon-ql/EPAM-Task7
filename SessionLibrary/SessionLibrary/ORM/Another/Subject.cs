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

        public Subject()
        {

        }
        public override bool Equals(object obj)
        {
            return obj is Subject subject &&
                   Id == subject.Id &&
                   SubjectName == subject.SubjectName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1556104140;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubjectName);
            return hashCode;
        }
    }
}