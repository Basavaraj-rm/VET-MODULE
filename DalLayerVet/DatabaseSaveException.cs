using System;

namespace DalLayerVet
{
    public class DatabaseSaveException : ApplicationException
    {
        public DatabaseSaveException(string message) : base(message)
        {

        }
    }
}
