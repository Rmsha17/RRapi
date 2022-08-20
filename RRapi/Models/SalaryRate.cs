namespace RRapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalaryRate
    {
        public int ID { get; set; }

        public int CATEGORY_FID { get; set; }

        public decimal SALARY { get; set; }

        public virtual Category Category { get; set; }
    }
}
