using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace COMP003B.CodingAssignment6._8.Models;

public class Book
{
    public int BookId { get; set; }
   
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    // Collection navigation property
    
    public virtual ICollection<BookPurchase>? Purchases { get; set; }
    
    
}


