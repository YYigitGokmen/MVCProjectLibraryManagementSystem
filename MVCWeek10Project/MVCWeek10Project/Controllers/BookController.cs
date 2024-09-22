using Microsoft.AspNetCore.Mvc;
using MVCWeek10Project.Models;

namespace MVCWeek10Project.Controllers
{
    public class BookController:Controller
    {
        // In-memory book list for demonstration
        private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "Book One", AuthorId = 1, Genre = "Fiction", PublishDate = new DateTime(2020, 1, 1), ISBN = "123456789", CopiesAvailable = 5 },
        new Book { Id = 2, Title = "Book Two", AuthorId = 2, Genre = "Non-Fiction", PublishDate = new DateTime(2019, 5, 10), ISBN = "987654321", CopiesAvailable = 3 }
    };

        // List action
        public IActionResult List()
        {
            return View(books);
        }

        // Details action
        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Create action (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create action (POST)
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Max(b => b.Id) + 1;  // Simple ID increment
                books.Add(book);
                return RedirectToAction("List");
            }
            return View(book);
        }

        // Edit action (GET)
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Edit action (POST)
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.Genre = book.Genre;
            existingBook.PublishDate = book.PublishDate;
            existingBook.ISBN = book.ISBN;
            existingBook.CopiesAvailable = book.CopiesAvailable;

            return RedirectToAction("List");
        }

        // Delete action (GET)
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Delete action (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return RedirectToAction("List");
        }





    }
}
