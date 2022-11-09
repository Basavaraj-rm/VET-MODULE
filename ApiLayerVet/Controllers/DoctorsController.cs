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
        [Route("api/Doctor/Feedbacks/{doctorId}")]
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
        [Route("api/Doctor/Feedbacks/async/{doctorId}")]
        public async Task<IHttpActionResult> GET_FEEDBACK_ASYNC(int doctorId)
        {
            List<Feedback> feedbacks = await dataProcessor.getFeedbacksAsync(doctorId);
            if (feedbacks == null)
            {
                return BadRequest("not found");
            }
            else
            {
                return Ok(feedbacks);
            }
        }
        [HttpPost]
        [Route("api/Doctor/Feedback/{doctorId}")]
        public IHttpActionResult POST_FEEDBACK([FromUri()] int doctorId, [FromBody()] Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                bool done = dataProcessor.postFeedback(doctorId, feedback);
                if(done==false)
                {
                    return BadRequest("doctor ID not present");
                }
                else
                {
                    return Created($"api/Doctor/Feedback/{doctorId}", feedback);
                }
            }
            else
            {
                return BadRequest("model state is not valid");
            }
        }
        [HttpPost]
        [Route("api/Doctor/Feedback/async/{doctorId}")]
        public async Task<IHttpActionResult> POST_FEEDBACK_ASYNC([FromUri()] int doctorId, [FromBody()] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                bool done = await dataProcessor.postFeedbackAsync(doctorId, feedback);
                if (done == false)
                {
                    return BadRequest("doctor ID not present");
                }
                else
                {
                    return Created($"api/Doctor/Feedback/{doctorId}", feedback);
                }
            }
            else
            {
                return BadRequest("model state is not valid");
            }
        }
    }
}
