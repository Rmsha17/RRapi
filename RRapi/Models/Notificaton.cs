namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notificaton
    {
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string MESSAGE { get; set; }

        public int WRITER_FID { get; set; }

        public DateTime DATETIME { get; set; }
        [JsonIgnore]
        public virtual Writer Writer { get; set; }
    }
}
