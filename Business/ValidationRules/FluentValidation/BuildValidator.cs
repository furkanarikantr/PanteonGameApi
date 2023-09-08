using Business.Constants.ValidationMessages;
using Entity.Concrete.MongoDbEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BuildValidator :  AbstractValidator<Build>
    {
        public BuildValidator()
        {
            RuleFor(b => b.BuildType).NotEmpty().WithMessage(BuildValidatorMessages.BuildTypeMustBeChosen);
            RuleFor(b => b.BuildType).NotNull().WithMessage(BuildValidatorMessages.BuildTypeMustBeChosen); 

            RuleFor(b => b.BuildCost).NotEmpty().WithMessage(BuildValidatorMessages.BuildCostMustNotEmpty); 
            RuleFor(b => b.BuildCost).NotNull().WithMessage(BuildValidatorMessages.BuildCostMustNotEmpty); 
            RuleFor(b => b.BuildCost).GreaterThan(0).WithMessage(BuildValidatorMessages.BuildCostBeGreaterThan);

            RuleFor(b => b.ConstructionTime).NotEmpty().WithMessage(BuildValidatorMessages.ConstructionTimeMustNotEmpty);
            RuleFor(b => b.ConstructionTime).NotNull().WithMessage(BuildValidatorMessages.ConstructionTimeMustNotEmpty);
            RuleFor(b => b.ConstructionTime).GreaterThan(30).WithMessage(BuildValidatorMessages.ConstructionTimeBeGreaterThan); 
            RuleFor(b => b.ConstructionTime).LessThan(1800).WithMessage(BuildValidatorMessages.ConstructionTimeCannotBeLessThan); 
        }
    }
}
