using System.ComponentModel.DataAnnotations;

namespace Library_DB;

public abstract class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } 
    public Author Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }
    public int AvailableCopies { get; set; }
    public int AuthorId { get; set; }
    public BookDetails BookDetails { get; set; }
}