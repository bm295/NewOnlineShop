namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContentTag")]
    public partial class ContentTag
    {
        [Key]
        [Column(Order = 0)]
        public long ContentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TagId { get; set; }
    }
}
