namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? Active { get; set; }

        [StringLength(150)]
        public string Username { get; set; }

        public int RoleID { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
