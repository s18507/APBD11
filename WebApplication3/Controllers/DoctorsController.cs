
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        readonly IDbService _dbService;
      
        public DoctorsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult getDoctor()
        {
            ICollection<Doctor> doctors = _dbService.getDoctor();
            if (doctors == null)
                return BadRequest();
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult addDoctor(Doctor doctor)
        {
            Doctor newDoctor = _dbService.createDoctor(doctor);
            if (newDoctor == null)
                return BadRequest();
            return Ok(newDoctor);
        }

        [HttpPost("update")]
        public IActionResult updateDoctor(Doctor doctor)
        {
            Doctor newDoctor = _dbService.updateDoctor(doctor);
            if (newDoctor == null)
                return BadRequest();
            return Ok(newDoctor);
        }

        [HttpDelete("deleate/{id}")]
        public IActionResult deleteDoctor(int id)
        {
            Doctor doctor = _dbService.deleteDoctor(id);
            if (doctor == null)
                return BadRequest();
            return Ok(doctor);
        }
    }
}