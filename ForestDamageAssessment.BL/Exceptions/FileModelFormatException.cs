using System.Runtime.Serialization;

namespace ForestDamageAssessment.BL.Exceptions
{
    public class FileModelFormatException : Exception
    {
        public FileModelFormatException() : base() { }
        public FileModelFormatException(string message) : base(message) { }
        public FileModelFormatException(string message, Exception innerException) : base(message, innerException) { }
        protected FileModelFormatException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}