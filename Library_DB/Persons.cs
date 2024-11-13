using System.ComponentModel.DataAnnotations.Schema;

namespace Library_DB;

    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    [Table("Authors")]
    public class Author : Person {
        public string Biography { get; set; }
    }
    [Table("Customers")]
    public class Customer : Person {
        public DateTime MembershipDate { get; set; }
    }
    [Table("Librarians")]
    public class Librarian : Person {
        public string EmployeeId { get; set; }
    } 

