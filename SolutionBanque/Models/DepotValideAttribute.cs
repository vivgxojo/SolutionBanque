using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolutionBanque.Models
{
    public class DepotValideAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value == null) { return true; }
            return ((decimal)value) >= 0;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            List<ModelClientValidationRule> liste = new List<ModelClientValidationRule>();
            liste.Add(new ModelClientValidationRule()
            {
                ValidationType = "depotvalide",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            });
            return liste;
        }

    }
}