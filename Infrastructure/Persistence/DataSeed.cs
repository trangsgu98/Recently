using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class DataSeed
    {
        public static void Initialize(RegisterContext context)
        {
           
            context.Database.EnsureCreated();
            
            // DB has seeded
            if (context.Patients.Any()) return;
            // { 

             /*   context.Patients.AddRange(
                    
                    new Patient("B001", "Nguyen Ha", Gender.female, System.DateTime.Parse("1989-12-6"), 
                                new Address("147E", "Phạm Ngũ Lão", "Quận 1", "TPHCM", "Việt Nam"),"0978546234"),
                
                    new Patient("B004", "Van Duc", Gender.male, System.DateTime.Parse("1996-8-9"), 
                                new Address("19A"," Đường số 148", "Huyện Hóc Môn", "TPHCM", "Việt Nam"),"09794567895"),

                    new Patient("T008", "Văn Trung", Gender.male,  System.DateTime.Parse("1996-8-10"), 
                                new Address("24D", "An Dương Vương", "Quận 5", "TPHCM", "Việt Nam"),"09794567878"),

                    new Patient("T745",  "Nguyễn Thị Hoa", Gender.female, System.DateTime.Parse("1996-10-9"), 
                                new Address("48C", "Hai Bà Trưng", "Quận 1", "TPHCM", "Việt Nam"),"03694567895")
                );
                context.SaveChanges();
            //}
           // if (!context.Doctors.Any()) 
           // {
                context.Doctors.AddRange(
                     
                    new Doctor("S001", "Nguyen A", Gender.female , "0334578965"),
                    new Doctor("H008", "Nguyen B", Gender.male,  "0975658745")
                    );

                context.SaveChanges();

           // }

            //if (!context.Departments.Any()) 
            //{
                 context.Departments.AddRange(
                     
                    new Department("N1", "Khoa nội thần kinh", new Doctor("S002", "Nguyen A", Gender.female , "0334578965")),
                    new Department("S2", "Khoa sản", new Doctor("H009", "Nguyen B", Gender.male,  "0975658745"))
                     );

                 context.SaveChanges();*/

            //}

            var patients = new Patient[]
            {
                 new Patient
                {
                   PatientId="A001", 
                   PatientName="Nguyen Ha",
                   Gender = Gender.female,
                   Birthday = System.DateTime.Parse("1989-12-6"),
                   Address = new Address("198","Đường số 12","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "0337859647"
                   },
                new Patient
                {
                   PatientId = "B004", 
                   PatientName="Van Duc",
                   Gender = Gender.male,
                   Birthday = System.DateTime.Parse("1996-8-9"),
                   Address = new Address("19","Nguyễn Thượng Hiền","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "09794567895"               
                   }
            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p); // cung ten voi DbSet<Patient> Patient trong RegisterContext
            }
            context.SaveChanges();

            var doctors = new Doctor[]
            {
                // new Doctor
                // {
                //     DoctorId = "S001",
                //     DoctorName = "Nguyễn Thị Hà", 
                //     Gender = Gender.female, 
                //     Phone = "0334578965",
                //     DeptName = Depts.TM
                // },

                 new Doctor("H008","Châu Văn Thành", Gender.male, "0975658745","TN"),
                  new Doctor("N014","Lê Thị Hà Giang", Gender.female, "0975658745","SA"),
                   new Doctor("D985","Lương Thế Vinh", Gender.male, "0975658745","PT")

            };

            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d); // cung ten voi DbSet<Patient> Patient trong RegisterContext
            }

            context.SaveChanges();

            var departments = new Department[]
            {
                new Department
                {
                    DeptId = "SA",
                    DeptName = "Khoa Sản",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    DoctorHead = doctors.Single(d => d.DoctorId == "H008").DoctorName
                },
                new Department
                {
                    DeptId = "PT",
                    DeptName = "Khoa Phẫu Thuật",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    DoctorHead = doctors.Single(d => d.DoctorId == "N014").DoctorName
                }
                // new Department
                // {
                //     DeptId = "TM",
                //     DeptName = "Khoa Tim Mạch",
                //     // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                //     DoctorHead = doctors.Single(d => d.DoctorId == "NULL").DoctorName
                // },
                // new Department
                // {
                //     DeptId = "TN",
                //     DeptName = "Khoa Tim Mạch",
                //     // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                //     DoctorHead = doctors.Single(d => d.DoctorId == "NULL").DoctorName
                // }
            };
            foreach (Department dept in departments)
            {
                var DeptInData = context.Departments.Where(
                    dp =>
                            dp.Doctor.DoctorId == dept.DoctorId).SingleOrDefault();

                if (DeptInData == null)
                {
                    context.Departments.Add(dept);
                }
                //context.Departments.Add(dept); // cung ten voi DbSet<Patient> Patient trong RegisterContext

            }

            context.SaveChanges();
            

            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    PatientId = patients.Single(e => e.PatientName == "Nguyen Ha").PatientId,
                    DoctorId = doctors.Single(d => d.DoctorName == "Châu Văn Thành").DoctorId,
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                   EnrollmentDate = System.DateTime.Parse("1998-2-24")
                },
                new Enrollment
                {
                    PatientId = patients.Single(e => e.PatientName == "Van Duc").PatientId,
                    DoctorId = doctors.Single(d => d.DoctorName == "Lương Thế Vinh").DoctorId,
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                   EnrollmentDate = System.DateTime.Parse("2000-1-1")
                }
            };

                foreach (Enrollment e in enrollments)
                {
                    var EnrollInData = context.Enrollments.Where(
                        e =>
                                e.Doctor.DoctorId == e.DoctorId &&
                                e.Patient.PatientId == e.PatientId).SingleOrDefault();

                    if (EnrollInData == null)
                    {
                        context.Enrollments.Add(e);
                    }
                     // cung ten voi DbSet<Patient> Patient trong RegisterContext

                }

                context.SaveChanges();

        }
    }
}