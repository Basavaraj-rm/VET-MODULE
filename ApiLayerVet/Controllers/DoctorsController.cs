using DalLayerVet;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLayerVet.Controllers
{
    public class DoctorsController : ApiController
    {
        DoctorRepo repo = new DoctorRepo();
        [HttpGet]
        [Route("api/Doctor/Feedback/{doctorId}")]
        public IHttpActionResult GET_FEEDBACK(int doctorId)
        {
            List<Feedback> feedbacks = repo.getFeedbacks(doctorId);
            if (feedbacks == null)
            {
                return BadRequest("not found");
            }
            else
            {
                return Ok(feedbacks);
            }
        }
    }
}
