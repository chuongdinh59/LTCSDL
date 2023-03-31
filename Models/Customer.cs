namespace BuildingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
            Buildings = new HashSet<Building>();
        }

        public int ID { get; set; }

        public int AccountID { get; set; }

        [Column(TypeName = "text")]
        public string Avatar { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool? Status { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
