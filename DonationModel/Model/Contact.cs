using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Model;

public class Contact : AuditableEntity
{
    [Key]
    public int AccountNo { get; set; }
    [Required]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? Street { get;  set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }

    public ICollection<Donation>? Donations { get; set; }
}
