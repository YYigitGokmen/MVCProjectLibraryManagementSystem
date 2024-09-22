namespace MVCWeek10Project.Models
{
    public class BookDetailsViewModel
    {
        //Create a ViewModel that will display book details and related information.
        //This ViewModel can also be used for pages where books will be listed.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }

        // This is to display the author's information along with the book
        public string AuthorFullName { get; set; }
        public DateTime AuthorDateOfBirth { get; set; }

        // Optional: You can add more properties to enrich the view model
        public string UserFullName { get; set; } // In case you want to show who borrowed the book
        public DateTime? BorrowDate { get; set; } // Date when the book was borrowed, if relevant

        // For displaying a list of books on the same page
        public IEnumerable<Book> RelatedBooks { get; set; }

    }
}
