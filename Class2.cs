using System;

public class InputValidator
{
    public static byte GetValidByte(string prompt)
    {
        byte number;
        bool isValid;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            isValid = byte.TryParse(input, out number);

            if (!isValid)
            {
                Console.WriteLine("Ошибка: Введите целое число от 0 до 255.");
            }
        } while (!isValid);

        return number;
    }
}