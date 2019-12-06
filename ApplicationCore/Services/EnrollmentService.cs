using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using ApplicationCore.Specifications;
using System.Linq;
using ApplicationCore.Entities;
namespace ApplicationCore.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<string> GetNames()
        {
            return _unitOfWork.Doctors.GetNames();
        }

        public IQueryable<Enrollment> GetAllEnrollments()
        {
            //var all =  _unitOfWork.Enrollments.GetAllEnrollments();  
             return  _unitOfWork.Enrollments.GetAllEnrollments();  
            //return all.ProjectTo<EnrollmentsDTO>;
             //return _mapper.Map<IQueryable<Enrollment>, IQueryable<EnrollmentsDTO>>(all); 
        }

        
    }
}