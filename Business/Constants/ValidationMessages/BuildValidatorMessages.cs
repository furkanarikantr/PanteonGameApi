using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.ValidationMessages
{
    public static class BuildValidatorMessages
    {
        public static string BuildTypeMustBeChosen = "The Building Type Must be Selected!";

        public static string BuildCostMustNotEmpty = "The Building Cost Must be Entered!";
        public static string BuildCostBeGreaterThan = "The Building Cost Cannot be Greater Than Zero!";

        public static string ConstructionTimeMustNotEmpty = "The Construction Time Must be Entered!";
        public static string ConstructionTimeBeGreaterThan = "The Construction Time Be Greater Than Thirty!";
        public static string ConstructionTimeCannotBeLessThan = "The Construction Time Cannot be Less Than One Thousand Eight Hundred!";

    }
}
