using LatihanWebApplicationMVC.Data;
using LatihanWebApplicationMVC.Models;
using LatihanWebApplicationMVC.Models.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatihanWebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContextMVC dBContextMVC;

        public EmployeeController(DBContextMVC dBContextMVC)
        {
            this.dBContextMVC = dBContextMVC;
        }

        [HttpGet]
        public async Task<IActionResult> ViewEmployee()
        {
            var employee = await dBContextMVC.Employees.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            var employee = new Employee()
            {
                Nama = addEmployeeViewModel.Nama,
                Alamat = addEmployeeViewModel.Alamat,
                Usia = addEmployeeViewModel.Usia,
                TanggalLahir = addEmployeeViewModel.TanggalLahir
            };
            await dBContextMVC.Employees.AddAsync(employee);
            await dBContextMVC.SaveChangesAsync();
            return RedirectToAction("ViewEmployee");


        }

        [HttpGet]
        public async Task<IActionResult> EditView(int id)
        {
            var employee = await dBContextMVC.Employees.FirstOrDefaultAsync(x => x.Id == id);
            
            if( employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Nama = employee.Nama,
                    Alamat = employee.Alamat,
                    Usia = employee.Usia,
                    TanggalLahir = employee.TanggalLahir
                };
                return View(viewModel);
            }
           
            return Redirect("ViewEmployee");
        }

        [HttpPost]
        public async Task<IActionResult> EditView(UpdateEmployeeViewModel model) {
            var employee = await dBContextMVC.Employees.FindAsync(model.Id);
            if (employee != null) {
                employee.Nama = model.Nama;
                employee.Alamat = model.Alamat;
                employee.Usia = model.Usia;
                employee.TanggalLahir = model.TanggalLahir;
                
                await dBContextMVC.SaveChangesAsync();

                return RedirectToAction("ViewEmployee");
            }
            return RedirectToAction("ViewEmployee");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await dBContextMVC.Employees.FindAsync(model.Id);

            if(employee != null)
            {
                dBContextMVC.Employees.Remove(employee);
                await dBContextMVC.SaveChangesAsync();

                return RedirectToAction("ViewEmployee");
            }
            return RedirectToAction("ViewEmployee");
        }

        }
}
