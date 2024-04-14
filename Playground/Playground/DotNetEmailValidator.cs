using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Playground
{
    public class DotNetEmailValidator
    {

 
        public static bool Validate(string email)
        {
            
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
           
        }

       
    }
}
