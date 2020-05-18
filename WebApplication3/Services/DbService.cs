using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class DbService : IDbService
    {
        private DoctorDbContext _dbContext;

        public DbService(DoctorDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public Doctor createDoctor(Doctor doctor)
        {
            _dbContext.Doctor.Add(doctor);
            _dbContext.SaveChanges();
            return _dbContext.Doctor.Where(d =>
                    d.FirstName == doctor.FirstName && d.LastName == doctor.LastName && d.Email == doctor.Email)
                .FirstOrDefault();
        }

        public Doctor deleteDoctor(int id)
        {
            Doctor doctor = _dbContext.Doctor.Where(d => d.IdDoctor == id).FirstOrDefault();
            _dbContext.Doctor.Remove(doctor);
            _dbContext.SaveChanges();
            return doctor;
        }

        public ICollection<Doctor> getDoctor()
        {
            return _dbContext.Doctor.ToList();
        }

        public void seedDb()
        {
           
            _dbContext.Doctor.Add(new Doctor { FirstName = "Kuba", LastName = "Andrzejewski", Email = "kubaandrz@gmail.com" });
            _dbContext.Doctor.Add(new Doctor { FirstName = "Artur", LastName = "Kowalski", Email = "kowalski@gmail.com" });
            _dbContext.Doctor.Add(new Doctor { FirstName = "Patrycja", LastName = "Gruszewska", Email = "patrycja1@gmail.com" });
           
            _dbContext.Patient.Add(new Patient { FirstName = "Alina", LastName = "Jabluszewska", BirthDate = DateTime.Parse("03-10-1997") });
            _dbContext.Patient.Add(new Patient { FirstName = "Patryk", LastName = "Malewski", BirthDate = DateTime.Parse("20-05-2000") });
            _dbContext.Patient.Add(new Patient { FirstName = "Andrzej", LastName = "Biskwit", BirthDate = DateTime.Parse("31-10-1999") });
            _dbContext.Patient.Add(new Patient { FirstName = "Kamil", LastName = "Rura", BirthDate = DateTime.Parse("05-07-1996") });
           
            _dbContext.Prescription.Add(new Prescription { Date = DateTime.Today, IdDoctor = 1, IdPatient = 1, DueDate = DateTime.Now });
            _dbContext.Prescription.Add(new Prescription { Date = DateTime.Now, IdDoctor = 2, IdPatient = 3, DueDate = DateTime.Now });
          
            _dbContext.Medicament.Add(new Medicament { Name = "dwad", Dose = 2 });
            _dbContext.Medicament.Add(new Medicament { Name = "atox", Dose = 5 });
            _dbContext.SaveChanges();
        }

        public Doctor updateDoctor(Doctor doctor)
        {
            Doctor doctorUpdate = _dbContext.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();
            doctorUpdate.Email = doctor.Email;
            doctorUpdate.Prescriptions = doctor.Prescriptions;
            doctorUpdate.FirstName = doctor.FirstName;
            doctorUpdate.LastName = doctor.LastName;
            _dbContext.SaveChanges();
            Doctor newDoctor = _dbContext.Doctor.Where(d => d.IdDoctor == doctor.IdDoctor).FirstOrDefault();
            return doctor;
        }
    }
}
