using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{
    [Table(Name = "Specification")]
    public class Specification
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column(Name = "SpecificationName")]
        public string SpecificationName { get; set; }

        public Specification(int id, string specificationName)
        {
            Id = id;
            SpecificationName = specificationName;
        }
    }
}
