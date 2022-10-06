namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Feedback()
        {
            Feedback1 = new HashSet<Feedback>();
        }

        [Key]
        public int FEEDBACK_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FEEDBACK_DESCRIPTION { get; set; }

        public int READER_FID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FEEDBACK_DATE { get; set; }

        public int ARTIFACT_FID { get; set; }

        public int? EPISODE_FID { get; set; }

        public int? FEEDBACK_FID { get; set; }
        [JsonIgnore]
        public virtual Artifact Artifact { get; set; }
        [JsonIgnore]
        public virtual Episode Episode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedback1 { get; set; }
        [JsonIgnore]
        public virtual Feedback Feedback2 { get; set; }
        [JsonIgnore]
        public virtual Reader Reader { get; set; }
        [NotMapped]
        public string READER_NAME { get; set; }
        [NotMapped]
        public string READER_IMAGE { get; set; }

    }
}
