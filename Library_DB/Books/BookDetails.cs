﻿namespace Library_DB.Books;

public class BookDetails
{
    public int Id { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public int BorrowedCopies { get; set; }
}