using System.Runtime.Serialization;

namespace ForestDamageAssessment.BL.Exceptions
{
    public class FileModelFormatDataException : Exception
    {
        public FileModelFormatDataException() : base() { }
        public FileModelFormatDataException(string message) : base(message) { }
        public FileModelFormatDataException(string message, Exception innerException) : base(message, innerException) { }
        protected FileModelFormatDataException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}