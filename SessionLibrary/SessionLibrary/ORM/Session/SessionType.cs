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
        public int Id { get; private set; }
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
    }
}
