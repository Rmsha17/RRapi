namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopArtifact")]
    public partial class ShopArtifact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShopArtifact()
        {
            Order_Details = new HashSet<Order_Details>();
        }

        public int ID { get; set; }

        public int? ARTIFACT_FID { get; set; }

        public decimal PURCHASE_PRICE { get; set; }

        public decimal SALE_PRICE { get; set; }
        [JsonIgnore]
        public virtual Artifact Artifact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order_Details> Order_Details { get; set; }
    }
}
