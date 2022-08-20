namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubCategory")]
    public partial class SubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategory()
        {
            Artifacts = new HashSet<Artifact>();
        }

        [Key]
        public int SUB_CATEGORY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SUB_CATEGORY_NAME { get; set; }

        public int CATEGORY_FID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Artifact> Artifacts { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
