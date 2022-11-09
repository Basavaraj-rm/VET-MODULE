using DalLayerVet;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public class DoctorDataProcessor
    {
        DoctorRepo repo = new DoctorRepo();
        public List<Feedback> getFeedbacks(int doctorId)
        {
            List<Feedback> feedbacks= repo.getFeedbacks(doctorId);
            return feedbacks;
        }
        public bool AddAppointment(int doctorId,DoctorAppointment appointmentId)
        {
            bool response = repo.AddAppointment(doctorId, appointmentId);
            return response;
        }
        public async Task<bool> _AddAppointment(int doctorId,DoctorAppointment appointmentId)
        {
            var response =  await repo._AddAppointment(doctorId, appointmentId);
            return response;
        }
    }
}
