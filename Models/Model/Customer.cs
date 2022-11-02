using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Model
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; } = null!;
        [StringLength(50)]
        public string FatherName { get; set; } = null!;
        [StringLength(50)]
        public string MotherName { get; set; } = null!;
        public int MaritalStatus { get; set; }
        public byte[] CustomerPhoto { get; set; } = null!;

        [ForeignKey("CountryId")]
        [InverseProperty("Customers")]
        public virtual Country? Country { get; set; } = null!;
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerAddress>? CustomerAddresses { get; set; }
    }
}
