using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.DTO;
namespace Examining.ViewModel
{
    public class DoctorPageVM
    {
        public SelectList Names { get; set; }
        public PaginatedList<DoctorsDTO> ListDoctor { get; internal set; }
    }
}