using System;

namespace Week6
{
    public class PhoneValidator
    {
        public static  bool ValidatePhoneNumber(string phoneNumber)
        {
            if(phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            return false;
        }
    }
}
