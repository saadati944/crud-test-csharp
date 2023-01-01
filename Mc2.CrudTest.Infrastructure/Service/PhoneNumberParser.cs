﻿using PhoneNumbers;

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
                throw new InvalidPhoneNumberException($"The entered number '{number}' does not have correct format.");

            // Concatinate CountryCode and NationalNumber
            ulong temp = parsedNumber.NationalNumber;
            int nationalNumberDigitsCount = parsedNumber.NumberOfLeadingZeros; ;
            while (temp > 0)
            {
                temp /= 10;
                nationalNumberDigitsCount++;
            }

            ulong finalNumber = (ulong)parsedNumber.CountryCode;
            while (nationalNumberDigitsCount > 0)
            {
                finalNumber *= 10;
                nationalNumberDigitsCount--;
            }
            finalNumber += parsedNumber.NationalNumber;

            return finalNumber;
        }
        catch(NumberParseException ex)
        {
            // Because we don't have any kind of i18n and exception messages
            // are not part of our business, there is no need to translate the
            // error messages of Google phone lib to our own error messages
            throw new InvalidPhoneNumberException(ex.Message);
        }
    }
}
