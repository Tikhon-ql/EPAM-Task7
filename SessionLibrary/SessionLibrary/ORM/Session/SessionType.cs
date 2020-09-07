using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Session
{
    /// <summary>
    /// Sessin type's class 
    /// </summary>
    [Table(Name = "SessionType")]
    public class SessionType
    {
        /// <summary>
        /// Session type's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        /// <summary>
        /// Session type's name property
        /// </summary>
        [Column(Name = "SessionTypeName")]
        public string SessionTypeName { get; set; }

        public SessionType(int id, string sessionTypeName)
        {
            Id = id;
            SessionTypeName = sessionTypeName;
        }
        public SessionType()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is SessionType type &&
                   SessionTypeName == type.SessionTypeName;
        }

        public override int GetHashCode()
        {
            int hashCode = -1419068980;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SessionTypeName);
            return hashCode;
        }
    }
}
