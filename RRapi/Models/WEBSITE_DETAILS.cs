namespace RRapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WEBSITE_DETAILS
    {
        [Key]
        public int WEBSITE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string WEBSITE_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string WEBSITE_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string WEBSITE_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string WEBSITE_CONTACT { get; set; }

        [StringLength(200)]
        public string WEBSITE_LOGO { get; set; }
    }
}
