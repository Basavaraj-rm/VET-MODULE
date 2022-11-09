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

        [HttpPost]
        [Route("api/Doctors/AssignAppointmentToDoctor/doctorId={doctorId}")]
        public IHttpActionResult Post(int doctorId, DoctorAppointment appointmentId)
        {
            bool response = dataProcessor.AddAppointment(doctorId, appointmentId);
            if (response)
                return Ok(); //200
            else
                return BadRequest("Doctor Id not available");
        }

        [HttpPost]
        [Route("api/Doctors/AssignAppointmentToDoctor/async/doctorId={doctorId}")]
        public async Task<IHttpActionResult> PostAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            var response = await dataProcessor._AddAppointment(doctorId, appointmentId);
            if (response==true)
                return Ok(); //200
            else
                return BadRequest("Doctor Id not available");
        }
    }
}
