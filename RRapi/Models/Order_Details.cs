namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Details
    {
        [Key]
        public int ORDERDETAIL_ID { get; set; }

        public int ORDER_FID { get; set; }

        public int SHOPARTIFACT_FID { get; set; }

        public decimal ARTIFACT_SALEPRICE { get; set; }

        public decimal ARTIFACT_PURCHASEPRICE { get; set; }

        public decimal QUANTITY { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public virtual ShopArtifact ShopArtifact { get; set; }
        [NotMapped]
        public string ARTIFACT_NAME { get; set; }
        [NotMapped]
        public string ARTIFACT_IMAGE { get; set; }
        [NotMapped]
        public decimal Total { get; set; }
       
    }
}
