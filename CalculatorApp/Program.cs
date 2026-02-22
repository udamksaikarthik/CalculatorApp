using System.Text.RegularExpressions;

namespace CalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Calculator App!");
            bool appFlag = true;

            // The app will continue to run until the user decides to exit by providing "no" when prompted.
            while (appFlag)
            {
                // Get the user's option for the desired operation (addition, subtraction, multiplication, division, or exit).
                string? userOption = GetUserOption();

                // If the user provides an invalid option, they will be prompted to enter a valid option until they do so.
                if (!string.IsNullOrEmpty(userOption))
                {
                    if(userOption.Trim() == "5")
                    {
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                    }
                    while (userOption == "Invalid")
                    {
                        userOption = GetUserOption();
                    }
                }

                // Get the first and second numbers from the user for the selected operation.
                double firstNum = GetNum("First");


                double secondNum = GetNum("Second");

                // Perform the selected operation on the two numbers and display the result to the user.
                if(userOption!= null)
                {
                    double result = Operation(firstNum, secondNum, userOption.Trim());
                    Console.WriteLine("Result: " + result);
                }


                // After displaying the result, the user will be asked if they want to perform another operation. If they respond with "yes", the app will continue to run and allow them to select another operation. If they respond with "no", the app will exit.
                Console.WriteLine("Thank you for using Calculator App. Would you like to perform one more operation(yes/no)?");


                bool appFlagTxtBool = true;

                // The user will be prompted to provide a valid response (yes/no) until they do so. If the user provides an invalid response, they will be informed of the invalid input and prompted again.
                while (appFlagTxtBool)
                {
                    string? appFlagTxt = GetAppFlagTxt();
                    if (appFlagTxt != null)
                    {
                        // If the user provides an invalid response, they will be informed of the invalid input and prompted again.
                        if (!appFlagTxt.Equals("yes") && !appFlagTxt.Equals("no"))
                        {
                            Console.WriteLine($"{appFlagTxt} is Invalid response. Please provide correct response (yes/no).");
                        }
                        else
                        {
                            // If the user provides a valid response, the app will check if the response is "yes" or "no". If the response is correct, the loop ends for flagTxt and the app continues to run or exits based on the user's response.
                            appFlagTxtBool = false;
                        }

                        // If the user provides "no", the app will exit by setting the appFlag to false, which will end the main loop and terminate the program.
                        if (appFlagTxt.Equals("no"))
                        {
                            appFlag = false;
                        }
                    }
                }
            }
        }

        // This method is responsible for getting the user's response to whether they want to perform another operation. It reads the user's input from the console, converts it to lowercase, and returns it as a string. If the user provides an invalid response, they will be informed of the invalid input and prompted again until they provide a valid response (yes/no).
        private static string? GetAppFlagTxt()
        {
            string? appFlagTxt = Console.ReadLine();
            if (appFlagTxt != null)
            {
                appFlagTxt = appFlagTxt.ToLower();



            }

            return appFlagTxt;
        }

        // This method is responsible for getting the user's option for the desired operation (addition, subtraction, multiplication, division, or exit). It displays a menu of options to the user and prompts them to select an option by entering a number between 1 and 5. The method validates the user's input to ensure it is a valid option and returns the selected option as a string. If the user provides an invalid option, they will be informed of the invalid input and prompted again until they provide a valid option.
        private static string? GetUserOption()
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
                    userOption = "5";
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
            }

            return userOption;
        }

        // This method is responsible for performing the selected operation (addition, subtraction, multiplication, or division) on the two numbers provided by the user. It takes the first number, second number, and the user's selected option as parameters and uses a switch statement to determine which operation to perform based on the user's selection. The method also handles division by zero by prompting the user to provide a valid number if they attempt to divide by zero. Finally, it returns the result of the operation as a double.
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
                default:
                    Console.WriteLine("Invalid");
                    break;
            }

            return result;
        }

        // This method is responsible for getting a valid number input from the user. It takes a string parameter (msg) to indicate whether the number being requested is the first or second number. The method uses a while loop to continuously prompt the user for input until a valid number is provided. It reads the user's input from the console and attempts to parse it as a double. If the parsing is successful, it returns the parsed number. If the parsing fails, it informs the user of the invalid input and prompts them again until a valid number is entered.
        private static double GetNum(string msg)
        {
            while (true)
            {
                Console.WriteLine($"Enter the {msg} number:");
                string? numInput = Console.ReadLine();
                if (double.TryParse(numInput, out double parsedNum))
                {
                    return parsedNum;
                }
                else
                {
                    Console.WriteLine($" {numInput} is Invalid. Invalid input provided, please try again!!");
                }
            }
        }
    }
}