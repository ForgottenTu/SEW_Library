using Library_DB.Books;
using Microsoft.EntityFrameworkCore;

namespace Library_DB;

public class LibraryContext:DbContext
{
    public DbSet<Book> Books { get; set; }
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
            .HasValue<SciFi>("ScienceFiction")
            .HasValue<Textbook>("Textbook")
            .HasValue<Mystery>("Mystery")
            .HasValue<NonFiction>("NonFiction")
            .HasValue<Fantasy>("Fantasy")
            .HasValue<Biography>("Biography");
        
        model.Entity<Person>().ToTable("Persons");
        model.Entity<Author>().ToTable("Authors");
        model.Entity<Customer>().ToTable("Customers");
        model.Entity<Librarian>().ToTable("Librarians");

        model.Entity<Book>()
            .HasOne(book => book.BookDetails)
            .WithOne()
            .HasForeignKey<Book>(Book => Book.Id);
        
        model.Entity<Book>()
            .HasOne(a => a.Author)
            .WithMany()
            .HasForeignKey(book => book.AuthorId);
        
        model.Entity<BookLoan>()
            .HasKey(bl => new {bl.BookId, bl.PersonId});
        
        model.Entity<BookLoan>()
            .HasOne(bl => bl.Book)
            .WithMany()
            .HasForeignKey(bl => bl.BookId);
        
        model.Entity<BookLoan>()
            .HasOne(bl => bl.Person)
            .WithMany()
            .HasForeignKey(bl => bl.PersonId);
    }
}