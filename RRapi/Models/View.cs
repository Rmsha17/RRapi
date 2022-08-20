namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("View")]
    public partial class View
    {
        [Key]
        public int VIEW_ID { get; set; }

        public DateTime VIEW_DATE { get; set; }

        public int READER_FID { get; set; }

        public int ARTIFACT_FID { get; set; }

        public int EPISODE_FID { get; set; }
        [JsonIgnore]
        public virtual Artifact Artifact { get; set; }
        [JsonIgnore]
        public virtual Episode Episode { get; set; }
        [JsonIgnore]
        public virtual Reader Reader { get; set; }
    }
}
