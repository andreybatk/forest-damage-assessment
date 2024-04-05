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
            services.AddTransient(typeof(IViolationService<TreeFellingViolationCalculate, ITreeViewModel>), typeof(TreeFellingViolationCalculate));
            services.AddTransient(typeof(IViolationService<BushFellingViolationCalculate, IBushViewModel>), typeof(BushFellingViolationCalculate));
            services.AddTransient(typeof(IViolationService<TreeFellingViolation2Calculate, ITreeViewModel>), typeof(TreeFellingViolation2Calculate));
            services.AddTransient(typeof(IViolationService<BushFellingViolation2Calculate, IBushViewModel>), typeof(BushFellingViolation2Calculate));

            services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            services.AddScoped<ITaxPriceRepository, TaxPriceRepository>();
        }
    }
}
