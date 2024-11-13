using Microsoft.EntityFrameworkCore;

namespace Library_DB;

public class LibraryContext:DbContext
{
    public DbSet<Book> Items { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<BookDetails> BookDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Library.db");
    }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Book>().HasDiscriminator<string>("BookType")
            .HasValue<Novel>("Novel")
            .HasValue<SciFi>("SciFi")
            .HasValue<Textbook>("Textbook")
            .HasValue<Mystery>("Mystery")
            .HasValue<NonFiction>("NonFiction")
            .HasValue<Fantasy>("Fantasy");
        
        model.Entity<Person>().ToTable("Persons");
        model.Entity<Author>().ToTable("Authors");
        model.Entity<Customer>().ToTable("Customers");
        model.Entity<Librarian>().ToTable("Librarians");

        model.Entity<Book>().HasOne<BookDetails>().WithOne().HasForeignKey<Book>(Book => Book.Id);
        
        model.Entity<Book>().HasOne<Author>().WithMany();
    }
}