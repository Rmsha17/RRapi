namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Episode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Episode()
        {
            Feedbacks = new HashSet<Feedback>();
            Views = new HashSet<View>();
        }

        [Key]
        public int EPISODE_ID { get; set; }

        public int ARTIFACT_FID { get; set; }

        public int EPISODE_NO { get; set; }

        [Required]
        [StringLength(100)]
        public string EPISODE_FILE { get; set; }

        public DateTime EPISODE_DATE { get; set; }

        public bool? Isapproved { get; set; }

        public decimal? EPISODE_PRICE { get; set; }
        [JsonIgnore]
        public virtual Artifact Artifact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<View> Views { get; set; }
    }
}
