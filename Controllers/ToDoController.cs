using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListMVC_1.Data;
using ToDoListMVC_1.Models;

namespace ToDoListMVC_1.Controllers
{
    public class ToDoController : Controller
    {

        private readonly ApplicationDbContext _context;



        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult>Index()
        {
            var tasks = await _context.ToDoItems.ToListAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoItem item)
        {

            if (ModelState.IsValid)
            {
                item.CreatedDate = DateTime.Now;
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);


            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoItem item)
        {
            if (id != item.Id) return NotFound();

            if (ModelState.IsValid) 
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(item);


        }

        public IActionResult Delete() 
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ToggleCompletion(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();

            item.IsCompleted = !item.IsCompleted;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
