namespace RRapi.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bookmark")]
    public partial class Bookmark
    {
        [Key]
        public int BOOKMARK_ID { get; set; }

        public int ARTIFACT_FID { get; set; }

        public int READER_FID { get; set; }

        [JsonIgnore]
        public virtual Artifact Artifact { get; set; }
        [JsonIgnore]
        public virtual Reader Reader { get; set; }
    }
}
