using System.Text.RegularExpressions;

namespace CalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App!");
            bool appFlag = true;
            while (appFlag)
            {

                string? userOption = getUserOption();

                if (!string.IsNullOrEmpty(userOption))
                {
                    while (userOption == "Invalid")
                    {
                        userOption = getUserOption();
                    }
                }


                double firstNum = GetNum("First");


                double secondNum = GetNum("Second");


                double result = Operation(firstNum, secondNum, userOption);

                Console.WriteLine("Result: " + result);

                Console.WriteLine("Thank you for using Calculator App. Would you like to perform one more operation(yes/no)?");


                bool appFlagTxtBool = true;
                while (appFlagTxtBool)
                {
                    string? appFlagTxt = GetAppFlagTxt();
                    if (appFlagTxt != null)
                    {

                        if (!appFlagTxt.Equals("yes") && !appFlagTxt.Equals("no"))
                        {
                            Console.WriteLine($"{appFlagTxt} is Invalid response. Please provide correct response (yes/no).");
                        }
                        else
                        {
                            appFlagTxtBool = false;
                        }

                        if (appFlagTxt.Equals("no"))
                        {
                            appFlag = false;
                        }
                    }
                }
            }
        }

        private static string? GetAppFlagTxt()
        {
            string? appFlagTxt = Console.ReadLine();
            if (appFlagTxt != null)
            {
                appFlagTxt = appFlagTxt.ToLower();



            }

            return appFlagTxt;
        }

        private static string? getUserOption()
        {

            Console.WriteLine("==== SIMPLE CALCULATOR ====\r\n\r\n1. Add\r\n2. Subtract\r\n3. Multiply\r\n4. Divide\r\n5. Exit");
            Console.WriteLine("Please select an option (1-5):");
            string? userOption = Console.ReadLine();

            if (userOption != null)
            {
                if (userOption.Trim() == "" || userOption.Equals(""))
                {
                    userOption = "Invalid";
                    Console.WriteLine("Invalid operation provided. Please try again selecting the correct operation:");
                }
                if (userOption.Equals("5"))
                {
                    Environment.Exit(0);
                }
                if(!Regex.IsMatch(userOption.Trim(), "^[1-5]$"))
                {
                    userOption = "Invalid";
                    Console.WriteLine("Invalid option provided. Please try again selecting the correct option[1-5]:");
                }
            }
            else
            {
                userOption = "Invalid";
                Console.WriteLine("Invalid operation provided. Please try again selecting the correct operation:");
                Environment.Exit(0);
            }

            return userOption;
        }

        private static double Operation(double firstNum, double secondNum, string? userOption)
        {
            double result = 0;

            switch (userOption)
            {
                case "1":
                    Console.WriteLine("******Addition Operation******");
                    result = firstNum + secondNum;
                    break;
                case "2":
                    Console.WriteLine("******Subtraction Operation******");
                    result = firstNum - secondNum;
                    break;
                case "3":
                    Console.WriteLine("******Multiplication Operation******");
                    result = firstNum * secondNum;
                    break;
                case "4":
                    if (secondNum == 0)
                    {
                        Console.WriteLine("Division by zero is not possible. Please provide a valid number");
                        secondNum = GetNum("Second");
                        result = Operation(firstNum, secondNum, userOption);
                    }
                    else
                    {
                        Console.WriteLine("******Division Operation******");
                        result = firstNum / secondNum;
                    }
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }

            return result;
        }

        private static double GetNum(string msg)
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