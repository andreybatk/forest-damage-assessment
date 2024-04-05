namespace ForestDamageAssessment.DB.Interfaces
{
    public interface IAssortmentRepository
    {
        Task<IAssortment?> GetAssortmentAsync(string breed, string thicknessLevel, string rankH);
    }
}