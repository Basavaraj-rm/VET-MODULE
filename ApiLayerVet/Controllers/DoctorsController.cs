using BussinessLayerVet;
using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiLayerVet.Controllers
{
    public class DoctorsController : ApiController
    {
        IDoctorDataProcessor dataProcessor = new DoctorDataProcessor();
        [HttpGet]
        [Route("api/Doctor/Feedback/{doctorId}")]
        public IHttpActionResult GET_FEEDBACK(int doctorId)
        {
            List<Feedback> feedbacks = dataProcessor.getFeedbacks(doctorId);
            if (feedbacks == null)
            {
                return BadRequest("not found");
            }
            else
            {
                return Ok(feedbacks);
            }
        }

        public IHttpActionResult Post(DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Doctor doctor = dataProcessor.AddDoctor(doctorDto);
            if (doctor == null)
                throw new Exception("Couldn't able to add this doctor");
            return Created($"api/doctors/{doctor.doctorId}", doctor);

        }

        [Route("api/doctors/async")]
        public async Task<IHttpActionResult> PostAsync(DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Doctor doctor = await dataProcessor.AddDoctorAsync(doctorDto);
            if (doctor == null)
                throw new Exception("Couldn't able to add this doctor");
            return Created($"api/doctors/async/{doctor.doctorId}", doctor);

        }
    }
}
