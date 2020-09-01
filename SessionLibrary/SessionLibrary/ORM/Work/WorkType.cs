using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Work
{
    /// <summary>
    /// Work type's class
    /// </summary>
    public class WorkType
    {
        /// <summary>
        /// Work type's id property
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Work type' name property
        /// </summary>
        public string WorkTypeName { get; set; }

        public WorkType(int id, string workTypeName)
        {
            Id = id;
            WorkTypeName = workTypeName;
        }
    }
}
