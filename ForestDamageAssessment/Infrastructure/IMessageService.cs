namespace ForestDamageAssessment.Infrastructure
{
    public interface IMessageService
    {
        Task Send(string email, string subject, string message);
    }
}