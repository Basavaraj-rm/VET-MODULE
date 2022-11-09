﻿using BussinessLayerVet;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace ApiLayerVet.Controllers
{
    public class DoctorsController : ApiController
    {
        DoctorDataProcessor dataProcessor = new DoctorDataProcessor();
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

        [HttpGet]
        [Route("api/Doctors")]
        [EnableQuery]
        public IQueryable<Doctor> GetDoctors()
        {
            return dataProcessor.GetDoctors().AsQueryable();
        }

        [HttpGet]
        [Route("api/Doctors/async")]
        [EnableQuery]
        public async Task<IQueryable<Doctor>> GetDoctorsAsync()
        {
            var data =  await dataProcessor.GetDoctorsAsync();
            
            return data.AsQueryable();
        }
    }
}
