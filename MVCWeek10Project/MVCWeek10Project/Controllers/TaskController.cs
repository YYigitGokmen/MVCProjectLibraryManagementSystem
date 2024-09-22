using Microsoft.AspNetCore.Mvc;
using ToDoAppPatika.Entities;
using ToDoAppPatika.Models;

namespace ToDoAppPatika.Controllers
{
    public class TaskController : Controller
    {
        static List<TaskEntity> _tasks = new List<TaskEntity>()
        {
            new TaskEntity{Id = 1, Title="Tutunamayanlar", Content = "Türk aydınının kimlik arayışını ve bu arayışın toplum ile etkileşimini anlatır.",OwnerId=1},
            new TaskEntity{Id = 2, Title="Sinekli Bakkal ", Content = "Meşrutiyet dönemi İstanbulunu anlatır."},
            new TaskEntity{Id = 3, Title="Kürk Mantolu Madonna", Content = "Raif efendinin gizemli bir kadına aşık olmasını anlatır.", IsDone = true},

        };

     
        static List<OwnerEntity> _owners = new List<OwnerEntity>()
        {

            new OwnerEntity{ Id = 1 , Name = " Oğuz Atay"},
            new OwnerEntity{ Id = 2 , Name = "Halide Edip Adıvar" },
            new OwnerEntity{ Id = 3 , Name = "Sabahattin Ali" }

        };

        public IActionResult List()
        { 
          

            var viewModel = _tasks.Where(x => x.IsDeleted == false).Select(x => new TaskListViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                IsDone = x.IsDone
            }).ToList();

           

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CompleteTask(int id)
        {

            var task = _tasks.Find(x => x.Id == id);

            task.IsDone = !task.IsDone;

            task.CompletedDate = DateTime.Now;

            return RedirectToAction("List");

            
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Owners = _owners;

            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskAddViewModel formData)
        {
           

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            int maxId = _tasks.Max(x => x.Id);

            var newTask = new TaskEntity()
            {
                Id = maxId + 1,
                Title = formData.Title,
                Content=formData.Content,
                OwnerId = formData.OwnerId
            };
  
            _tasks.Add(newTask);


            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var task = _tasks.Find(x => x.Id == id);

          
            var viewModel = new TaskEditViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Content = task.Content,
                OwnerId = task.OwnerId
            };

            ViewBag.Owners = _owners;

            
            return View(viewModel);

           
        }


        [HttpPost]
        public IActionResult Edit(TaskEditViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var task = _tasks.Find(x => x.Id == formData.Id);

            task.Title = formData.Title;
            task.Content = formData.Content;
            task.OwnerId = formData.OwnerId;




            return RedirectToAction("List");
        }


        public IActionResult CancelTask(int id)
        {
            var task = _tasks.Find(x => x.Id == id);

           

            task.IsDeleted = true; 


            return RedirectToAction("List");
        }
    }
}
