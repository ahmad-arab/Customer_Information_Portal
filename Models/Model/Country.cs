using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models.Model
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; } = null!;

        [InverseProperty("Country")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
