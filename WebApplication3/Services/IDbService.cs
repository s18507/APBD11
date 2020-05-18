using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IDbService
    {
        public void seedDb();
        public ICollection<Doctor> getDoctor();
        public Doctor createDoctor(Doctor doctor);
        public Doctor updateDoctor(Doctor doctor);
        public Doctor deleteDoctor(int id);
    }
}
