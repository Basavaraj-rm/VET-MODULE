using System;

namespace BussinessLayerVet
{
    public class DoctorDetailsInCompleteException : ApplicationException
    {
        public DoctorDetailsInCompleteException(string message) : base(message)
        {
        }
    }
}
