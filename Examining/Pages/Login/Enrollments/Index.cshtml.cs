using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Entities.PatientAggregate;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Services;
using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using ApplicationCore;
namespace Examining.Pages.Login.Enrollments
{
    public class IndexModel : PageModel
    {
        private int pageSize = 5;
        private readonly IEnrollmentService _service;
        public IndexModel(IEnrollmentService service)
        {
            _service = service;
        } 
        public SelectList DoctorName { get; set; }
        public PaginatedList<Enrollment> ListEnrollment { get; set; }

        public async Task OnGetAsync(string searchString, int pageIndex = 1)
        {
            ViewData["searchString"] = searchString;
            //int count;

            IQueryable<Enrollment> enrollments = _service.GetAllEnrollments();

            //  var doctorName = _service.GetNames();

            // if (!string.IsNullOrEmpty(searchString))
            // {
            //     enrollments = enrollments.Where(e => e.DoctorId.Contains(searchString));
            // }

            
             //DoctorName = new SelectList(doctorName.Distinct().ToList());

            ListEnrollment = await PaginatedList<Enrollment>.CreateAsync(enrollments, pageIndex, pageSize);
        }
       
        
    }
}

