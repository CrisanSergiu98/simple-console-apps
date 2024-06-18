const int CreditCardLength = 16;

string creditCardNumber = "3379513561108795";

Console.WriteLine(ValidateCardNumber(creditCardNumber));

static bool ValidateCardNumber(string input)
{
    if(string.IsNullOrWhiteSpace(input) || input.Length != CreditCardLength)
    {
        return false;
    }

    int sum = 0;

    //Using the Luhn Algorithm we are multiplying the even possitions by 2.
    //If the sum is greater than 9, we are adding the digits together.
    for (int i = 0; i < CreditCardLength; i++)
    {
        int currentDigit = input[i] - '0';

        if (i % 2 == 0)
        {
            if(currentDigit * 2 > 9)
            {  
                sum += ((currentDigit * 2) % 10) + 1;
            }
            else
            {
                sum += currentDigit * 2;
            }
        }
        else
        {
            sum += currentDigit;
        }
    }

    //If the sum of the processed digits is divisible by 10, the card number is valid.
    return sum % 10 == 0;
}
