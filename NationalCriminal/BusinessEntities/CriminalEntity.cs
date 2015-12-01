using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace BusinessEntities
{


    public partial class CriminalEntity
    {
        public long Id { get; set; }
        
        [StringLength(50)]
        public string FName { get; set; }

        [StringLength(50)]
        public string LName { get; set; }

        public int? Age { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(10)]
        public string Height { get; set; }

        public double? Weight { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }
    }
}
