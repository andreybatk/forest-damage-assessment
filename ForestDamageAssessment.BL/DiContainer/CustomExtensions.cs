using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Services;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ForestDamageAssessment.BL.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, FileMessageService>();
            services.AddScoped<IForestAreaService, ForestAreaService>();
            services.AddScoped<IFileModelService, FileModelService>();
            services.AddScoped<ISeedlingsService, SeedlingsService>();
            services.AddScoped<IPlantationFellingService, PlantationFellingService>();
            services.AddScoped<IResinFellingService, ResinFellingService>();
            services.AddScoped(typeof(IExtendedViolationService<TreeFellingViolationService, ITreeViewModel>), typeof(TreeFellingViolationService));
            services.AddScoped(typeof(IExtendedViolationService<BushFellingViolationService, IBushViewModel>), typeof(BushFellingViolationService));
            services.AddScoped(typeof(IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel>), typeof(TreeFellingViolation2Service));
            services.AddScoped(typeof(IExtendedViolationService<BushFellingViolation2Service, IBushViewModel>), typeof(BushFellingViolation2Service));
            services.AddScoped(typeof(IViolationService<DeadFellingViolationService, ITreeViewModel>), typeof(DeadFellingViolationService));

            services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            services.AddScoped<ITaxPriceRepository, TaxPriceRepository>();
            services.AddScoped<ITaxPriceResinRepository, TaxPriceResinRepository>();
            services.AddScoped<IBreedDiameterModelRepository, BreedDiameterModelRepository>();
            services.AddScoped<ISTDRepository, STDRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
        }
    }
}