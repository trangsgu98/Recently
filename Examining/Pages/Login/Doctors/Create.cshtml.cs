using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Entities.DoctorAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Examining.Pages.Login.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly IDoctorService _service;

         [BindProperty]
        public Doctor Doctor { get; set; }

        public SelectList AllDept{get; set;}

        // [BindProperty]
        // public Doctor Doct { get; set; }
        public CreateModel(IDoctorService servie)
        {
            _service = servie;
        }

        public void OnGet()
        {
            var allDept = _service.GetAllDept();

            AllDept = new SelectList(allDept.Distinct().ToList());
        }

       

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             var id = new Doctor();
             if (await TryUpdateModelAsync<Doctor>(
                 id,
                 "Doctor",   // Prefix for form value.
                 d => d.DoctorId, d => d.DoctorName, d => d.Gender, d => d.Phone, d => d.DeptId))
            
            _service.CreateDoctor(Doctor);

            return RedirectToPage("./Index");
        }
    }
}
