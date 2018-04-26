
using System.Text.RegularExpressions;

namespace GeekHunter
{
    public class InputValidation
    {
        public InputValidation() { }

        
        public string Validate(string input, int minLength, int maxLength)
        {
            if(string.IsNullOrEmpty(input))
            {
                return null; 
            }

            string output = input.Trim().Replace(" ", "");

            if (output.Length >= minLength && output.Length <= maxLength)
            {
                return output;
            }else
            {
                return null;
            }
            
        }

        public bool EmailValidate(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$");
            if(regex.Match(email).Success)
            {
                return true;
            }
            return false;
        }
    }
}
