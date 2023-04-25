namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManagementBuilding")]
    public partial class ManagementBuilding
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BuildingID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsSuccess { get; set; }

        public virtual Building Building { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
