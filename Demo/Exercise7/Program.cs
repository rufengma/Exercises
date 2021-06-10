using System;

namespace Exercise7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int balance = 1000;
            Console.WriteLine("Enter your pin number");
            int pinNumber = Convert.ToInt32(Console.ReadLine());
            if (pinNumber != 000)
            {
                Console.WriteLine("Your Pin is Incorrect, please contact the customer care");
            }
            else {
                Console.WriteLine("*************Welcome to ATM Service ***************");
                Console.WriteLine("1. Check Blance\n2. Withdraw Cash\n3. Deposit Cash\n4. Quit");
                Console.WriteLine("****************************");
                Console.WriteLine("Enter your choice:");
                int service = Convert.ToInt32(Console.ReadLine());
                switch (service)
                {
                    case 1:
                        Console.WriteLine("YOU'RE BALANCE IN Rs: " + balance);
                        break;
                    case 2:
                        Console.WriteLine("How much cash do you need?");
                        break;
                    case 3:
                        Console.WriteLine("Please put your cash in the machine.");
                        break;
                    case 4:
                        Console.WriteLine("Thank you for your coming!");
                        break;
                }

            }

        }
    }
}
