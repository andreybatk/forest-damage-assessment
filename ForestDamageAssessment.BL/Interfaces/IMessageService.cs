namespace ForestDamageAssessment.BL.Interfaces
{
    public interface IMessageService
    {
        Task Send(string email, string subject, string message);
    }
}