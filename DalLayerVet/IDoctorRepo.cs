using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public interface IDoctorRepo
    {
        void addDoctor(Doctor doctor);
        List<Feedback> getFeedbacks(int doctorId);

    }
}
