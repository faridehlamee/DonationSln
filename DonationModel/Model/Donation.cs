using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Model;
using System.ComponentModel.DataAnnotations.Schema;


namespace DonationModel.Model
{
    public class Donation : AuditableEntity
    {
        [Key]
        public int TransId { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public float Amount { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("AccountNo")]
        public virtual Contact? Contact { get; set; }

        public int AccountNo { get; set; }

        [ForeignKey("TransactionTypeId")]
        public virtual TransactionType? TransactionType { get; set; }

        public int TransactionTypeId { get; set; }

        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public int PaymentMethodId { get; set; }

    }
}