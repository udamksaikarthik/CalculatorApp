
namespace CalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App!");
            Console.WriteLine("==== SIMPLE CALCULATOR ====\r\n\r\n1. Add\r\n2. Subtract\r\n3. Multiply\r\n4. Divide\r\n5. Exit");
            Console.WriteLine("Please select an option (1-5):");

            string? userOption = Console.ReadLine();

            Console.WriteLine("userOption: " + userOption);

            double firstNum = getNum("First");

            Console.WriteLine("First Number: " + firstNum);

            double secondNum = getNum("Second");

            Console.WriteLine("Second Number: " + secondNum);

        }

        private static double getNum(string msg)
        {
            while (true)
            {
                Console.WriteLine($"Enter the {msg} number:");
                string? firstNumInput = Console.ReadLine();
                if (double.TryParse(firstNumInput, out double parsedFirstNum))
                {
                    return parsedFirstNum;
                }
                else
                {
                    Console.WriteLine($" {firstNumInput} is Invalid. Invalid input provided, please try again!!");
                }
            }
        }
    }
}