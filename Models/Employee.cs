namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ID { get; set; }

        public int AccountID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? ManagementBuildingID { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Avatar { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ManagementBuilding ManagementBuilding { get; set; }
    }
}
