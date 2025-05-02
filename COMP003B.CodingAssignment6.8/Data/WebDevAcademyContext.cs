using COMP003B.CodingAssignment6._8.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.CodingAssignment6._8.Data;

public class WebDevAcademyContext : DbContext
{
    public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BookPurchase> BookPurchases { get; set; }
}