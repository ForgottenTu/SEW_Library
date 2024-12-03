using System.ComponentModel.DataAnnotations.Schema;

namespace Library_DB.Books;

public class BookLoan
{
    public Book Book { get; set; }
    [Column("BookId")]
    public int BookId { get; set; }
    public Person Person { get; set; }
    [Column("PersonId")]
    public int PersonId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public int LibrarianId { get; set; }
    public int? ReturnLibrarianId { get; set; }
    public DateTime? ReturnDate { get; set; }
}