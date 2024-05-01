using class_11.Data;
using class_11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace class_11.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;    
        }


        //synchronous and asynchronous


        //=============================== synchronous ================================================

        //public IActionResult Index()
        //{
        //    List<EmployeeViewModel> data =  _context.tblEmployee.ToList();
        //    return View(data);
        //}


        //=============================== asynchronous ================================================
        public async Task<IActionResult> Index()
        {
            List<EmployeeViewModel> data = await _context.tblEmployee.ToListAsync();
            return View(data);
        }

        //=============================== synchronous ================================================
        public IActionResult Create()
        {
            return View();
        }


        //=============================== synchronous ================================================
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult Create(EmployeeViewModel emp)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _context.tblEmployee.Add(emp);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Employee");
        //    }
        //    return View(emp);

        //}
        //=============================== asynchronous ================================================
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                await _context.tblEmployee.AddAsync(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employee");
            }
            return View(emp);

        }

        //=============================== synchronous ================================================
        //public IActionResult Delete(int id)
        //{
        //    if (id <= 0) return NotFound();

        //    EmployeeViewModel emp = _context.tblEmployee.FirstOrDefault(x => x.Id ==id );

        //    if (emp == null) return NotFound();

        //    _context.tblEmployee.Remove(emp);   
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Employee");

        //}

        //=============================== asynchronous ================================================
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            EmployeeViewModel emp = await _context.tblEmployee.FirstOrDefaultAsync(x => x.Id == id);

            if (emp == null) return NotFound();

            _context.tblEmployee.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Employee");

        }

        //=============================== synchronous ================================================

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    if (id <= 0) return NotFound();

        //    EmployeeViewModel emp = _context.tblEmployee.FirstOrDefault(x => x.Id == id);

        //    if (emp == null) return NotFound();

        //    return View(emp);
        //}

        //=============================== asynchronous ================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0) return NotFound();

            EmployeeViewModel emp = await _context.tblEmployee.FirstOrDefaultAsync(x => x.Id == id);

            if (emp == null) return NotFound();

            return View(emp);
        }


        //=============================== synchronous ================================================
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public IActionResult Edit(EmployeeViewModel emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.tblEmployee.Update(emp);
        //        _context.SaveChanges(true);
        //        return RedirectToAction("Index", "Employee");
        //    }

        //    return View(emp);
        //}

        //=============================== asynchronous ================================================
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                _context.tblEmployee.Update(emp);
                await _context.SaveChangesAsync(true);
                return RedirectToAction("Index", "Employee");
            }

            return View(emp);
        }
    }
}
