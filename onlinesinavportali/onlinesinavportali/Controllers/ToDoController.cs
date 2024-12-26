using Microsoft.AspNetCore.Mvc;
using onlinesinavportali.Models;
using onlinesinavportali.ViewModels;

namespace onlinesinavportali.Controllers
{
    public class ToDoController : Controller
    {
        private readonly AppDBContext _context;

        public ToDoController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TodoListAjax()
        {
            var todoModels = _context.ToDoLists.Select(x => new ToDoListModel()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).ToList();

            return Json(todoModels);
        }
        public IActionResult TodoByIdAjax(int id)
        {
            var todoModel = _context.ToDoLists.Where(s => s.Id == id).Select(x => new ToDoList()
            {
                Id = x.Id,
                Title = x.Title,
                Status = x.Status,
            }).SingleOrDefault();

            return Json(todoModel);
        }

        [HttpPost]
        public IActionResult TodoAddEditAjax(ToDoListModel model)
        {
            var sonuc = new SonucModel();
            if (model.Id == 0)
            {

                if (_context.ToDoLists.Count(c => c.Title == model.Title) > 0)
                {
                    sonuc.Status = false;
                    sonuc.Message = "Girilen Başlık Kayıtlıdır!";
                    return Json(sonuc);
                }

                var todo = new ToDoList() 
                {
                    Title = model.Title,
                    Status = model.Status,
                };                
                _context.ToDoLists.Add(todo);
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Eklendi";
            }
            else
            {
                var todo = _context.ToDoLists.FirstOrDefault(x => x.Id == model.Id);
                todo.Status = model.Status;
                todo.Title = model.Title;
                _context.SaveChanges();
                sonuc.Status = true;
                sonuc.Message = "İşlem Güncellendi";
            }

            return Json(sonuc);
        }
        public IActionResult TodoRemoveAjax(int id)
        {
            var todo = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            _context.ToDoLists.Remove(todo);
            _context.SaveChanges();

            var sonuc = new SonucModel();
            sonuc.Status = true;
            sonuc.Message = "İşlem Silindi";
            return Json(sonuc);
        }
    }
}
