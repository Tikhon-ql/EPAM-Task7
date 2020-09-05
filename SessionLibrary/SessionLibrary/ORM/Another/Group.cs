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
        public Group()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Group group &&
                   Id == group.Id &&
                   GroupName == group.GroupName &&
                   SpecificationId == group.SpecificationId;
        }

        public override int GetHashCode()
        {
            int hashCode = 551239054;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            hashCode = hashCode * -1521134295 + SpecificationId.GetHashCode();
            return hashCode;
        }
    }
}
