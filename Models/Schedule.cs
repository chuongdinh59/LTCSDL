namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int ID { get; set; }

        [Required]
        [StringLength(256)]
        public string BuildingID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime? Time { get; set; }

        public bool? Session { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
