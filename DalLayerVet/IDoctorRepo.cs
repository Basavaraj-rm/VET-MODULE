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
        List<Feedback> getFeedbacks(int doctorId);
        bool EditDoctor(Doctor doctor,int id);
        Task<bool> EditDoctorasync(Doctor doctor,int id);

    }
}
