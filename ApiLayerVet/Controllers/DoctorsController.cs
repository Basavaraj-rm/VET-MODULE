using BussinessLayerVet;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

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
        [EnableQuery]
        public IQueryable<Doctor> GetDoctors()
        {
            return dataProcessor.GetDoctors().AsQueryable();
        }

        [HttpGet]
        [Route("api/async/Doctors")]
        public async Task<IQueryable<Doctor>> GetDoctorsAsync()
        {
            return (IQueryable<Doctor>)await dataProcessor.GetDoctorsAsync();
        }
    }
}
