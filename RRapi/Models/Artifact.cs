namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Artifact")]
    public partial class Artifact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artifact()
        {
            Bookmarks = new HashSet<Bookmark>();
            Episodes = new HashSet<Episode>();
            Feedbacks = new HashSet<Feedback>();
            ShopArtifacts = new HashSet<ShopArtifact>();
            Views = new HashSet<View>();
        }

        [Key]
        public int ARTIFACT_ID { get; set; }

        [Required]
        [StringLength(200)]
        public string ARTIFACT_NAME { get; set; }

        [Required]
        [StringLength(200)]
        public string ARTIFACT_PICTURE { get; set; }

        [Required]
        [StringLength(50)]
        public string ARTIFACT_DATE { get; set; }

        [Required]
        [StringLength(2000)]
        public string ARTIFACT_DESCRIPTION { get; set; }

        public int SUB_CATEGORY_FID { get; set; }

        public int WRITER_FID { get; set; }

        public int? SCHEDULE_FID { get; set; }

        [StringLength(20)]
        public string ARTIFACT_STATUS { get; set; }
        [JsonIgnore]

        public virtual Schedule Schedule { get; set; }
        [JsonIgnore]
        public virtual SubCategory SubCategory { get; set; }
        [JsonIgnore]
        public virtual Writer Writer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Episode> Episodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ShopArtifact> ShopArtifacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<View> Views { get; set; }
    }
}
