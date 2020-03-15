using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_Winform_Model.Service
{
    public class Check_Input_Service
    {
        //數字 : 1 ~ ∞
        public bool IsInteger(string value)
        {
            string pattern = @"^[1-9][0-9]*$";
            return Regex.IsMatch(value, pattern);
        }

        //數字 : -∞ ~ ∞
        public bool 整數Integer(string value)
        {
            string pattern = @"^-?\d+$";
            return Regex.IsMatch(value, pattern);
        }
        //數字 : 0.00 ~ 0.99
        public bool 小數點2位(string value)
        {
            string pattern = @"^([0]{1,}[.][0-9]{0,2})$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
