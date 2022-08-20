namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Writer")]
    public partial class Writer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Writer()
        {
            Artifacts = new HashSet<Artifact>();
            Notificatons = new HashSet<Notificaton>();
            Withdraw_Amount = new HashSet<Withdraw_Amount>();
        }

        [Key]
        public int WRITER_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string WRITER_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string WRITER_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string WRITER_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string WRITER_CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string WRITER_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string WEITER_GENDER { get; set; }

        public int ADMIN_FID { get; set; }

        [Required]
        [StringLength(100)]
        public string WRITER_IMAGE { get; set; }

        public int? STATUS { get; set; }

        [StringLength(50)]
        public string EXPERIENCE { get; set; }

        [StringLength(200)]
        public string SHARE_FILE_WORK { get; set; }
        [JsonIgnore]
        public virtual Admin Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Artifact> Artifacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Notificaton> Notificatons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Withdraw_Amount> Withdraw_Amount { get; set; }
    }
}
