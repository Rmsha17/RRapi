namespace RRapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            Writers = new HashSet<Writer>();
        }

        [Key]
        public int ADMIN_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string ADMIN_CONTACT { get; set; }

        [Required]
        [StringLength(100)]
        public string ADMIN_IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Writer> Writers { get; set; }
    }
}
