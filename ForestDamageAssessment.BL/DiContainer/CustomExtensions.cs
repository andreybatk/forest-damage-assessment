﻿using ForestDamageAssessment.BL.Interfaces;
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
            services.AddTransient<IForestAreaService, ForestAreaService>();
            services.AddTransient<IFileModelService, FileModelService>();
            services.AddTransient<ISeedlingsService, SeedlingsService>();
            services.AddTransient(typeof(IExtendedViolationService<TreeFellingViolationService, ITreeViewModel>), typeof(TreeFellingViolationService));
            services.AddTransient(typeof(IExtendedViolationService<BushFellingViolationService, IBushViewModel>), typeof(BushFellingViolationService));
            services.AddTransient(typeof(IExtendedViolationService<TreeFellingViolation2Service, ITreeViewModel>), typeof(TreeFellingViolation2Service));
            services.AddTransient(typeof(IExtendedViolationService<BushFellingViolation2Service, IBushViewModel>), typeof(BushFellingViolation2Service));
            services.AddTransient(typeof(IViolationService<DeadFellingViolationService, ITreeViewModel>), typeof(DeadFellingViolationService));

            services.AddScoped<IAssortmentRepository, AssortmentRepository>();
            services.AddScoped<ITaxPriceRepository, TaxPriceRepository>();
            services.AddScoped<IBreedDiameterModelRepository, BreedDiameterModelRepository>();
            services.AddScoped<ISTDRepository, STDRepository>();
        }
    }
}