namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BuildingID { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "text")]
        public string URL { get; set; }

        public virtual Building Building { get; set; }
    }
}
