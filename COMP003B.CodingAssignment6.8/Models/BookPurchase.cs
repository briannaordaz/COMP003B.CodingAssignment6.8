namespace COMP003B.CodingAssignment6._8.Models;

public class BookPurchase
{
    public int BookPurchaseId { get; set; }
    
    public int BookId { get; set; }
    
    public int CustomerId { get; set; }
    
    // Nullable navigation properties
    public virtual Book? Book { get; set; }
    public virtual Customer? Customer { get; set; }
}