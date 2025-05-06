using System.ComponentModel.DataAnnotations;

namespace COMP003B.CodingAssignment6._8.Models;

public class Customer
{
    public int CustomerId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string  Email { get; set; }
    
    // Collection navigation property
    public virtual ICollection<BookPurchase>? Purchases { get; set; }
    
    [Phone]
    public string PhoneNumber { get; set; } //New property added
    
}