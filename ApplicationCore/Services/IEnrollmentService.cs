using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using System.Linq;
using ApplicationCore.Entities;
namespace ApplicationCore.Services
{
    public interface IEnrollmentService
    {
        IQueryable<Enrollment> GetAllEnrollments();
    }
}