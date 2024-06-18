const int CreditCardLength = 16;

string creditCardNumber = "3379513561108795";

Console.WriteLine(ValidateCardNumber(creditCardNumber));

static bool ValidateCardNumber(string input)
{
    //Converting the string into an int array
    int[] cardDigits = new int[CreditCardLength];

    for (int i = 0; i < CreditCardLength; i++)
    {
        cardDigits[i] = input[i] - '0';
    }    

    int sum = 0;

    //Using the Luhn Algorithm we are multiplying the even possitions by 2.
    //If the sum is greater than 9, we are adding the digits together
    for (int i = 0; i < CreditCardLength; i++)
    {
        if (i % 2 == 0)
        {
            if(cardDigits[i] * 2 > 9)
            {
                //Because the maximum sum we can get is 9*2 = 18. We can add 1 and the last digit.
                //Since the first digit will be always 1.
                sum += ((cardDigits[i] * 2) % 10) + 1;
            }
            else
            {
                sum += cardDigits[i] * 2;
            }
        }
        else
        {
            sum += cardDigits[i];
        }
    }
    Console.WriteLine("Sum of the processed digits: " + sum);
    return sum % 10 == 0;
}
