using SessionLibrary._DAO.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{

    /// <summary>
    /// Group's class
    /// </summary>
    [Table(Name = "Group")]
    public class Group
    {

        /// <summary>
        /// Group's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; private set; }
        
        /// <summary>
        /// Group's name property
        /// </summary>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }
        [Column(Name = "SpecificationId")]
        public int SpecificationId { get; set; }

        public Group(int id, string groupName,int specificationid)
        {
            Id = id;
            GroupName = groupName;
            SpecificationId = specificationid;
        }
    }
}
