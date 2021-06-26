using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static int minNum = 1000;
        private static int maxNum = 9999;
        private static Dictionary<int, string> guests = new Dictionary<int, string> ();
        private static Random r = new Random();
        private static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string output = Console.ReadLine();
            return output;
        }

        private static void GetUserInfo()
        {
            string otherGuest;
            do
            {
                string name = GetUserInput("Please input a name:");
                while (String.IsNullOrEmpty(name))
                {
                   name = GetUserInput("Please input a name:");
                }
                int number = GenerateRandomNumber(minNum, maxNum);
                AddGuestsToRaffle(number, name);
                otherGuest = GetUserInput("Do you want to add another name? Yes or No:").ToLower();
                while (String.IsNullOrEmpty(otherGuest))
                {
                    otherGuest = GetUserInput("Do you want to add another name? Yes or No:");
                }

            } while (otherGuest.Contains("yes"));
        }
        private static int GenerateRandomNumber(int min, int max)
        {
            int answer = r.Next(min, max);
            return answer;
        }
        private static void AddGuestsToRaffle(int number, string name)
        {
            if (!guests.ContainsKey(number))
            {
                guests.Add(number, name);
            }
        }
        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            
            List<int> numList = new List<int> { };
            foreach(KeyValuePair<int, string> guest in people)
            {
                numList.Add(guest.Key);
            }
            int winningNum = numList[r.Next(0, numList.Count)];
            return winningNum;


        }
        private static void PrintWinner()
        {
            int winner = GetRaffleNumber(guests);
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The winner is number {winner} and that is {guests[winner]}");

        }
        private static void PrintGuestNames()
        {
            foreach(KeyValuePair<int, string> guest in guests)
            {
                Console.WriteLine($"Name: {guest.Value} Ticket Number:{guest.Key}");
                Console.WriteLine();
                
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Partay!!!!");
            GetUserInfo();
            MultiLineAnimation();
            PrintGuestNames();
            PrintWinner();
            Console.ReadLine();

        }

        //Start writing your code here






        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
