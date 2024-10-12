using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number: ");
        Console.WriteLine($"Decoded to decimal: {Converter.BinaryToDecimal(Console.ReadLine())}");
    }

    public class Converter
    {
        public static int BinaryToDecimal(string binaryString)
        {
            if (string.IsNullOrEmpty(binaryString))
            {
                throw new ArgumentException("Строка не может быть пустой или null", nameof(binaryString));
            }

            int decimalValue = 0;
            int baseValue = 1; // 2^0

            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] != '0' && binaryString[i] != '1')
                {
                    throw new FormatException("Строка содержит недопустимые символы; только 0 и 1 допустимы.");
                }

                if (binaryString[i] == '1')
                {
                    decimalValue += baseValue;
                }
                baseValue *= 2;
            }

            return decimalValue;
        }
    }
}