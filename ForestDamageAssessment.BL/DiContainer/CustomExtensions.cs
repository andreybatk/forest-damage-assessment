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
            services.AddTransient<IMessageService, FileMessageService>();
            services.AddTransient<IForestAreaModelService, ForestAreaModelService>();
            services.AddTransient<IFileModelService, FileModelService>();
            services.AddTransient(typeof(IViolationService<TreeFellingViolationService, ITreeViewModel>), typeof(TreeFellingViolationService));
            services.AddTransient(typeof(IViolationService<BushFellingViolationService, IBushViewModel>), typeof(BushFellingViolationService));
            services.AddTransient(typeof(IViolationService<TreeFellingViolation2Service, ITreeViewModel>), typeof(TreeFellingViolation2Service));
            services.AddTransient(typeof(IViolationService<BushFellingViolation2Service, IBushViewModel>), typeof(BushFellingViolation2Service));

            services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            services.AddScoped<ITaxPriceRepository, TaxPriceRepository>();
            services.AddScoped<IBreedDiameterModelRepository, BreedDiameterModelRepository>();
            services.AddScoped<ISTDRepository, STDRepository>();
        }
    }
}