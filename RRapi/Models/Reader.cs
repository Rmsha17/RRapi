namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reader")]
    public partial class Reader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reader()
        {
            Bookmarks = new HashSet<Bookmark>();
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
            ReaderPremiums = new HashSet<ReaderPremium>();
            Views = new HashSet<View>();
        }

        [Key]
        public int READER_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string READER_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string READER_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string READER_PASSWORD { get; set; }

        [Required]
        [StringLength(500)]
        public string READER_IMAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string READER_CONTACT { get; set; }

        [StringLength(100)]
        public string READER_ADDRESS { get; set; }
        [Required]
        public bool IS_ACCOUNT_ACTIVATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Bookmark> Bookmarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<ReaderPremium> ReaderPremiums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<View> Views { get; set; }
    }
}
