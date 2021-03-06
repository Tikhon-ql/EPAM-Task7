﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLibrary.ORM.Another
{

    /// <summary>
    /// Gender's class
    /// </summary>
    [Table(Name = "Gender")]
    public class Gender
    {

        /// <summary>
        /// Gender's id property
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gender's name property
        /// </summary>
        [Column(Name = "GenderName")]
        public string GenderName { get; set; }
        public Gender(int id, string genderName)
        {
            Id = id;
            GenderName = genderName;
        }
        public Gender()
        {

        }

        public override bool Equals(object obj)
        {
            return obj is Gender gender &&
                   GenderName == gender.GenderName;
        }

        public override int GetHashCode()
        {
            return -476022661 + EqualityComparer<string>.Default.GetHashCode(GenderName);
        }
    }
}
