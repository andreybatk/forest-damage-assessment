using Microsoft.EntityFrameworkCore;
using ForestDamageAssessment.DB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ForestDamageAssessment.DB.Data
{
    public class ForestDamageAssessmentData : IForestDamageAssessmentData
	{
        private readonly ApplicationDbContext context;

        public ForestDamageAssessmentData(ApplicationDbContext Context)
        {
            this.context = Context;
        }
    }
}
