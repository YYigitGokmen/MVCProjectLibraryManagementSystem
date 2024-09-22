using Microsoft.AspNetCore.Mvc;
using MVCWeek10Project.Models;

namespace MVCWeek10Project.Controllers
{
    public class AuthorController: Controller
    {
        // In-memory author list for demonstration
        private static List<Author> authors = new List<Author>
    {
        new Author { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1975, 5, 20) },
        new Author { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1980, 3, 15) }
    };

        // List action
        public IActionResult List()
        {
            return View(authors);
        }

        // Details action
        public IActionResult Details(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Create action (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create action (POST)
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.Id = authors.Max(a => a.Id) + 1;  // Simple ID increment
                authors.Add(author);
                return RedirectToAction("List");
            }
            return View(author);
        }

        // Edit action (GET)
        public IActionResult Edit(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Edit action (POST)
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            var existingAuthor = authors.FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.DateOfBirth = author.DateOfBirth;

            return RedirectToAction("List");
        }

        // Delete action (GET)
        public IActionResult Delete(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Delete action (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            authors.Remove(author);
            return RedirectToAction("List");
        }

    }
}
