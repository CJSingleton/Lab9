using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSingleton_Lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names = new List<string> { "Alex", "Joan", "Jack", "Alice", "Matt" };

            List<string> hometown = new List<string> { "Detroit", "Chicago", "Philadelphia", "London", "Boston" };

            List<string> favFood = new List<string> { "Pizza", "Ice Cream", "Pad Thai", "Steak", "Pasta" };

            List<string> favColor = new List<string> { "Green", "Blue", "Red", "Yellow", "Orange" };

            List<string> roster = new List<string> { "Hometown", "Favorite Food", "Favorite Color" };

            bool exit = true;
            while (exit == true)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("Welcome to our class! This is the current class roster:");
                for (int i = 0; i < names.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {names[i]}");
                }
                Console.WriteLine("------------------------");

                int input = 0;
                bool addorlearn = false;
                bool add1 = false;
                bool learn = false;
                while (addorlearn == false)
                {
                    Console.WriteLine("Would you like to add a new student to this list or learn about one of the students? (choose a number)");
                    Console.WriteLine("1. Add new student");
                    Console.WriteLine("2. Learn about an existing student.");
                    try
                    {
                        int choice = 0;
                        choice = ValidateNum(Console.ReadLine());

                        if (choice == 1)
                        {
                            add1 = true;
                            addorlearn = true;
                        }
                        else if (choice == 2)
                        {
                            learn = true;
                            addorlearn = true;
                        }
                        else
                        {
                            Console.WriteLine("Please choose 1 or 2.");
                        }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                while (add1 == true)
                {
                    Console.WriteLine("Enter the new student's name:");
                    names.Add(Console.ReadLine());
                    Console.WriteLine("Enter the new student's hometown:");
                    hometown.Add(Console.ReadLine());
                    Console.WriteLine("Enter the new student's favorite food:");
                    favFood.Add(Console.ReadLine());
                    Console.WriteLine("Enter the new student's favorite color:");
                    favColor.Add(Console.ReadLine());
                    Console.WriteLine("All done! Would you like to add another new student to this list? (y/n)");
                    learn = true;
                    add1 = YesOrNo(Console.ReadLine().ToLower());
                }
                while (learn == true)
                {
                    input = 0;
                    try
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Which student would you like to learn about? (choose a number)");
                        for (int i = 0; i < names.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {names[i]}");
                        }
                        Console.WriteLine("------------------------");
                        input = ValidateNum(Console.ReadLine());
                        string n = names[input-1];
                        learn = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("The entry cannot be null. Press any key to continue.");
                        learn = true;
                        Console.ReadKey();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Please enter a number in the range of {1} to {names.Count()}. Press any key to continue.");
                        learn = true;
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Press any key to continue");
                        learn = true;
                        Console.ReadKey();
                    }
                }
                
                string selection = "0" ;
                bool learn2 = true;
                while (learn2 == true)
                {
                    try
                    {  
                        Console.WriteLine("------------------------");
                        Console.WriteLine($"You have chosen student [{input}]: {names[input - 1]}. What would you like to know about {names[input - 1]}? (choose from the following list)");
                        for (int i = 0; i < roster.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {roster[i]}");
                        }
                        Console.WriteLine("------------------------");
                        
                        selection = Console.ReadLine().ToLower();

                        if ((selection == "hometown") || (selection == 1.ToString()))
                        {
                            Console.WriteLine($"{names[input - 1]} is from {hometown[input - 1]}.");
                            Console.WriteLine("Would you like to know more? (y/n)");
                            learn2 = YesOrNo(Console.ReadLine());

                        }
                        if ((selection == "favorite food") || (selection == 2.ToString()))
                        {
                            Console.WriteLine($"{names[input - 1]}'s favorite food is {favFood[input - 1]}.");
                            Console.WriteLine("Would you like to know more? (y/n)");
                            learn2 = YesOrNo(Console.ReadLine());
                        }
                        if ((selection == "favorite color") || (selection == (3).ToString()))
                        {
                            Console.WriteLine($"{names[input - 1]}'s favorite color is {favColor[input - 1]}.");
                            Console.WriteLine("Would you like to know more? (y/n)");
                            learn2 = YesOrNo(Console.ReadLine());
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                Console.WriteLine("Would you like to start over? (y/n)");
                exit = YesOrNo(Console.ReadLine().ToLower());
            }
        }
        public static bool YesOrNo(string input)
        {
            if ((input == "y") || (input == "yes"))
            {
                return true;
            }
            else if ((input == "n") || (input == "no"))
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public static int ValidateNum(string input)
        {
            while (!Regex.IsMatch(input, @"^\d$"))
            {
                Console.WriteLine("Your input is invalid. Please try again.");
                input = Console.ReadLine();
            }
            return int.Parse(input);

        }

    }
}