using System;

namespace BussinessLayerVet
{
    public class DoctorDetailsNotCompleteException : ApplicationException
    {
        public DoctorDetailsNotCompleteException(string message) : base(message)
        {
        }
    }
}
