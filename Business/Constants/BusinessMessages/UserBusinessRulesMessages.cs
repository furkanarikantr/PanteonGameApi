using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.BusinessMessages
{
    public static class UserBusinessRulesMessages
    {
        public static string UserAccepted = "The New User Added Successfully";

        public static string CheckIfUsernameAlreadyTaken = "The Username Has Already Been Taken. Please Enter a Different Username!";
        public static string CheckIfEmailAlreadyTaken = "The Email Has Already Been Taken. Please Enter a Different Email!";

        public static string CheckIfUsernameAndPasswordIsTrue = "The User Login Correct!";
        public static string CheckIfUsernameAndPasswordIsFalse = "The User Login Wrong! Check Your Information!";

    }
}
