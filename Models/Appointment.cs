namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string BuildingID { get; set; }

        public int? EmployeeID { get; set; }

        public int? CustomerID { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
