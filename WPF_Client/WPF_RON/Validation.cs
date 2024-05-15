using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_RON
{
    public class ValidationMovieShowName : ValidationRule
    {
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string text = value as string;
                Regex letter = new Regex("[a-zA-z]");
                if (text.Length > Max)
                {
                    return new ValidationResult(false, "too long");
                }
                if (text.Length == 0)
                {
                    return new ValidationResult(false, "too short");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

            return ValidationResult.ValidResult;
        }
    }
    public class ValidationLength : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string len = value as string;
                Regex letter = new Regex("[0-9]");
                if (len.Length > 3)
                {
                    return new ValidationResult(false, "too long");
                }
                for (int i = 0; i < len.Length; i++)
                {
                    if (!Char.IsDigit(len[i]))
                        return new ValidationResult(false, "must contain only digits");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

            return ValidationResult.ValidResult;
        }
    }
    public class ValidationUserName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string username = value as string;
                Regex letter = new Regex("[a-zA-z]");
                if (username.Length > 12)
                {
                    return new ValidationResult(false, "text can't be longer than 12");
                }
                if (!letter.IsMatch(username))
                {
                    return new ValidationResult(false, "text must contain a letter");
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

            return ValidationResult.ValidResult;
        }
    }

    public class ValidationPassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string passwsord = value as string;
                Regex digit = new Regex("[0-9]");
                Regex uppercase = new Regex("[A-Z]");
                Regex lowercase = new Regex("[a-z]");
                Regex specialChar = new Regex("[!@#$%^&*]");
                //CiniMeter1$
                if (passwsord.Length < 6)
                {
                    return new ValidationResult(false, "password must be at least 6 chars long"); // check if the password lenght is 8
                }
                if (passwsord.Length > 15)
                {
                    return new ValidationResult(false, "password must cann't be more then 15 chars"); // check if the password lenght is 8
                }
                else if (!digit.IsMatch(passwsord))
                {
                    return new ValidationResult(false, "password must contain digit"); // search lowercase letter
                }
                else if (!uppercase.IsMatch(passwsord))
                {
                    return new ValidationResult(false, "password must contain uppercase letter"); // search uppercase letter
                }
                else if (!lowercase.IsMatch(passwsord))
                {
                    return new ValidationResult(false, "password must contain lowercase letter"); // search digit
                }
                else if (!specialChar.IsMatch(passwsord))
                {
                    return new ValidationResult(false, "password must contain special char"); // search special char
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

            return ValidationResult.ValidResult;
        }
    }
}


