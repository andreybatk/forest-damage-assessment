﻿using ForestDamageAssessment.BL.Abstractions;
using ForestDamageAssessment.BL.Interfaces;

namespace ForestDamageAssessment.BL.Models
{
    public class BushViewModel : ViolationViewModelBase, IBushViewModel
    {
        public int? BushCount { get; set; }
        public string? BreedBush { get; set; }
        public string? BushType { get; set; }
    }
}