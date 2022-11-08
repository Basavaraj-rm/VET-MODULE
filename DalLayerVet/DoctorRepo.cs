using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class DoctorRepo:IDoctorRepo
    {
        VetDbContext db = new VetDbContext();
        public List<Feedback> getFeedbacks(int doctorId)
        {
            var data = db.Doctors.Find(doctorId);
            if(data == null)
            {
                return null;
            }
            else
            {
                return data.feedbacks; 
            }
        }
        public bool postFeedback(int doctorId,Feedback feedback)
        {
            var data = db.Doctors.Find(doctorId);
            if(data==null)
            {
                return false;
            }
            else
            {
                data.feedbacks.Add(feedback);
                db.SaveChanges();
                return true;
            }
        }

    }
}
