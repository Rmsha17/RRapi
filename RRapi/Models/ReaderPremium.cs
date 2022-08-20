namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReaderPremium")]
    public partial class ReaderPremium
    {
        [Key]
        public int BUYPREMIUM_ID { get; set; }

        public int READER_FID { get; set; }

        public int PREMIUM_FID { get; set; }

        public DateTime BUY_DATE { get; set; }

        public DateTime PREMIUM_END_DATE { get; set; }
        [JsonIgnore]
        public virtual Premium Premium { get; set; }
        [JsonIgnore]
        public virtual Reader Reader { get; set; }
    }
}
