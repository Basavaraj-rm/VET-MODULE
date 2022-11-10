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
        IDoctorDataProcessor dataProcessor = null;

        public DoctorsController(IDoctorDataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor;
        }


        public IHttpActionResult Post(DoctorDto doctorDto)
        {
            try
            {
                Doctor doctor = dataProcessor.AddDoctor(doctorDto);
                return Created($"api/doctors/{doctor.doctorId}", doctor);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/doctors/async")]
        public async Task<IHttpActionResult> PostAsync(DoctorDto doctorDto)
        {
            try
            {
                Doctor doctor = await dataProcessor.AddDoctorAsync(doctorDto);
                return Created($"api/doctors/async/{doctor.doctorId}", doctor);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
