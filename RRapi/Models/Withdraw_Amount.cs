namespace RRapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Withdraw_Amount
    {
        public int ID { get; set; }

        [Column("WITHDRAW_AMOUNT")]
        public decimal WITHDRAW_AMOUNT1 { get; set; }

        public DateTime REQDATETIME { get; set; }

        public int WRITER_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string PAYPAL_ACCOUNT { get; set; }

        public bool? ISTRANSFERED { get; set; }

        public DateTime RECDATETIME { get; set; }

        public virtual Writer Writer { get; set; }
    }
}
