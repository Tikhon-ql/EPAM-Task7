using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Work
{
    /// <summary>
    /// Work type's class
    /// </summary>
    [Table(Name = "WorkType")]
    public class WorkType
    {
        /// <summary>
        /// Work type's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        /// <summary>
        /// Work type' name property
        /// </summary>
        [Column(Name = "WorkTypeName")]
        public string WorkTypeName { get; set; }

        public WorkType(int id, string workTypeName)
        {
            Id = id;
            WorkTypeName = workTypeName;
        }
    }
}
