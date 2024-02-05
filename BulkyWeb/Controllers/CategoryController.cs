using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        // Assign constructor parameter db to the local variable _db to use this inside any other action method
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Retieve the categories
        public IActionResult Index()
        {
            // can access db sets categories which converts that to a list
            // this will then run the SQL statement to retrieve all categories from the table
            // and assign it to the objCategoryList variable
            List<Category>objCategoryList = _db.Categories.ToList();
            return View(objCategoryList); // passing categories to the view
        }

        //returns the view
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category categoryObj)
        {
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order cannot be the same as Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(categoryObj); // keeps track of what needs to be added

                // goes to the DB and creates the category
                // once the category is added, it will reload and pass it to the view
                _db.SaveChanges();
                return RedirectToAction();
            }
            return View();


            
        }


    }
}
