using PhoneNumbers;

namespace Mc2.CrudTest.Infrastructure.Service;

public class PhoneNumberParser : IPhoneNumberParser
{
    public ulong Parse(string number)
    {
        var phoneNumberUtils = PhoneNumberUtil.GetInstance();

        try
        {
            var parsedNumber = phoneNumberUtils.Parse(number, null);
            
            if(parsedNumber is null || !parsedNumber.HasNationalNumber || !parsedNumber.HasCountryCode)
                throw new InvalidPhoneNumberException();

            return ulong.Parse(phoneNumberUtils.Format(parsedNumber, PhoneNumberFormat.E164)[1..]);
        }
        catch(NumberParseException)
        {
            // Because we don't have any kind of i18n and exception messages
            // are not part of our business, there is no need to translate the
            // error messages of Google phone lib to our own error messages
            throw new InvalidPhoneNumberException();
        }
    }
}
