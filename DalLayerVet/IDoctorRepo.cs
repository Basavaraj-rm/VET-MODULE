using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public interface IDoctorRepo
    {
        Doctor SaveDoctor(Doctor doctor);
        Task SaveDoctorAsync(Doctor doctor);
    }
}
