namespace MVCWeek10Project.Models
{
    public class AuthorListViewModel
    {
        //Create a ViewModel that will be used for pages that will list
        //author details and authors.

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Combine first and last name for convenience

        // Optionally, you can include a list of books written by this author
        public IEnumerable<BookViewModel> BooksWritten { get; set; }
    }
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
    }

}

