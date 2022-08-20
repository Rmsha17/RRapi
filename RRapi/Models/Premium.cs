namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Premium
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Premium()
        {
            ReaderPremiums = new HashSet<ReaderPremium>();
        }

        [Key]
        public int PREMIUM_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PREMIUM_NAME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PREMIUM_PRICE { get; set; }

        public int DURATION_IN_MONTHS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ReaderPremium> ReaderPremiums { get; set; }
    }
}
