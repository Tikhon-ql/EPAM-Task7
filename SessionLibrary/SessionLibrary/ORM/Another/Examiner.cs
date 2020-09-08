using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    /// <summary>
    /// Examinesr's class
    /// </summary>
    [Table(Name = "Examiner")]
    public class Examiner
    {
        /// <summary>
        /// Examiner's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// Examiner's name property
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Examiner's surname property
        /// </summary>
        [Column(Name = "Surname")]
        public string Surname { get; set; }
        /// <summary>
        /// Examiner's midle name's property
        /// </summary>
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

        public override bool Equals(object obj)
        {
            return obj is Examiner examiner &&
                   Name == examiner.Name &&
                   Surname == examiner.Surname &&
                   MidleName == examiner.MidleName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1412885901;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MidleName);
            return hashCode;
        }
    }
}
