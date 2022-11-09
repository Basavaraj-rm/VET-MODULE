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
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

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

       
        [Route("api/Doctor/{id}")]
        public IHttpActionResult PutDoctor(Doctor d,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (!dataProcessor.editDoctor(d,id))
                return BadRequest("Doctor ID Invalid");
            return Ok();
        }
        [Route("api/Doctor/Async/{id}")]
        public async Task<IHttpActionResult> PutDoctorAsync(Doctor d,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            bool x = await dataProcessor.editDoctorAsync(d,id);
            if (!x)
                return BadRequest("Doctor Id Invalid");
            else
                return Ok();
        }
    }
}
