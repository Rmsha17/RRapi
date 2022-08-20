namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        [Key]
        public int ORDER_ID { get; set; }

        public DateTime ORDER_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_STATUS { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_TYPE { get; set; }

        public int? READER_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string PAYMENT_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        [JsonIgnore]
        public virtual Reader Reader { get; set; }
    }
}
