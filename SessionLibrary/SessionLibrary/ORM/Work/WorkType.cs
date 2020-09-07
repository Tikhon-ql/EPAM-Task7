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
        public int Id { get; set; }
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
        public WorkType()
        {

        }
        public override bool Equals(object obj)
        {
            return obj is WorkType type &&
                   WorkTypeName == type.WorkTypeName;
        }

        public override int GetHashCode()
        {
            int hashCode = -1239779125;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(WorkTypeName);
            return hashCode;
        }
    }
}
