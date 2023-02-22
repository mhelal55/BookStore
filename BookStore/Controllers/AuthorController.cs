using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorServices _services;
        public AuthorController(IAuthorServices services)
        {
            _services = services;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result=_services.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfuly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Erro has accured to server side";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            var result= _services.FindById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result=_services.Update(model);
            if (result)
            {
                TempData["msg"] = "updated Successfuly";
                return RedirectToAction(nameof(Update));
            }
            TempData["msg"] = "Erro has accured to server side";

            return View(model);
        } 
        public IActionResult Delete(int Id)
        {


            var result=_services.Delete(Id);
       
            return RedirectToAction("GetAll");
        }
        public IActionResult GetAll()
        {


            var result=_services.GetAll();

            return View(result);
        }
    }
}
