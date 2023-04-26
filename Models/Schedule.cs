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

        [StringLength(255)]
        public string BuildingID { get; set; }

        public DateTime? Time { get; set; }

        public int? EmployeeID { get; set; }

        public int? CustomerID { get; set; }

        public bool? IsResolve { get; set; }

        public bool? Session { get; set; }

        public virtual Building Building { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
