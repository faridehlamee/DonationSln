using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace DonationModel.Model
{
    public class PaymentMethod : AuditableEntity
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Required]
        public string? Name { get; set; }  

        public ICollection<Donation>? Donations { get; set; }        
    }
}