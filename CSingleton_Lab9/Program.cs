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
            List<Student> Roster = new List<Student>();

            Student temp = new Student();
            
            temp.FirstName = "Alex";
            temp.LastName = "Henderson";
            temp.Hometown = "Detroit";
            temp.FavoriteFood = "Pizza";
            temp.FavoriteColor = "Green";

            Roster.Add(temp);
            temp = new Student();

            temp.FirstName = "Joan";
            temp.LastName = "Sprocket";
            temp.Hometown = "Chicago";
            temp.FavoriteFood = "Ice Cream";
            temp.FavoriteColor = "Blue";

            Roster.Add(temp);
            temp = new Student();

            temp.FirstName = "Jack";
            temp.LastName = "Jackson";
            temp.Hometown = "Philedalphia";
            temp.FavoriteFood = "Pad Thai";
            temp.FavoriteColor = "Red";

            Roster.Add(temp);
            temp = new Student();

            temp.FirstName = "Alice";
            temp.LastName = "Redding";
            temp.Hometown = "London";
            temp.FavoriteFood = "Steak";
            temp.FavoriteColor = "Yellow";

            Roster.Add(temp);
            temp = new Student();

            temp.FirstName = "Matt";
            temp.LastName = "Smith";
            temp.Hometown = "Boston";
            temp.FavoriteFood = "Pasta";
            temp.FavoriteColor = "Orange";

            Roster.Add(temp);

            List<string> infoOptions = new List<string> { "Hometown", "Favorite Food", "Favorite Color"};

            bool exit = true;
            while (exit == true)
            {
                
                Console.WriteLine("------------------------");
                Console.WriteLine("Welcome to our class! This is the current class roster:");
                for (int i = 0; i < Roster.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}. {Roster[i].FirstName} {Roster[i].LastName}");
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
                    temp = new Student();

                    Console.WriteLine("Enter the new student's first name:");
                    temp.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter the new student's last name:");
                    temp.LastName = Console.ReadLine();
                    Console.WriteLine("Enter the new student's hometown:");
                    temp.Hometown = Console.ReadLine();
                    Console.WriteLine("Enter the new student's favorite food:");
                    temp.FavoriteFood = Console.ReadLine();
                    Console.WriteLine("Enter the new student's favorite color:");
                    temp.FavoriteColor = Console.ReadLine();

                    Roster.Add(temp);

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
                        for (int i = 0; i < Roster.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {Roster[i].FirstName} {Roster[i].LastName}");
                        }
                        Console.WriteLine("------------------------");
                        input = ValidateNum(Console.ReadLine());
                        string n = Roster[input-1].FirstName;
                        learn = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("The entry cannot be null. Press any key to continue.");
                        
                        Console.ReadKey();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"Please enter a number in the range of {1} to {Roster.Count()}. Press any key to continue.");
                        
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Press any key to continue");
                        
                        Console.ReadKey();
                    }
                }
                
                string selection = "0" ;
                bool learn2 = true;
                    do
                    {
                        try
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine($"You have chosen student [{input}]: {Roster[input - 1].FirstName} {Roster[input - 1].LastName}. What would you like to know about {Roster[input - 1].FirstName}? (choose from the following list)");
                            for (int i = 0; i < infoOptions.Count(); i++)
                            {
                                Console.WriteLine($"{i + 1}. {infoOptions[i]}");
                            }
                            Console.WriteLine("------------------------");

                            selection = Console.ReadLine().ToLower();

                            if ((selection == "hometown") || (selection == 1.ToString()))
                            {
                                Console.WriteLine($"{Roster[input - 1].FirstName} is from {Roster[input - 1].Hometown}.");
                                Console.WriteLine("Would you like to know more? (y/n)");
                                learn2 = YesOrNo(Console.ReadLine());

                            }
                            else if ((selection == "favorite food") || (selection == 2.ToString()))
                            {
                                Console.WriteLine($"{Roster[input - 1].FirstName}'s favorite food is {Roster[input - 1].FavoriteFood}.");
                                Console.WriteLine("Would you like to know more? (y/n)");
                                learn2 = YesOrNo(Console.ReadLine());
                            }
                            else if ((selection == "favorite color") || (selection == (3).ToString()))
                            {
                                Console.WriteLine($"{Roster[input - 1].FirstName}'s favorite color is {Roster[input - 1].FavoriteColor}.");
                                Console.WriteLine("Would you like to know more? (y/n)");
                                learn2 = YesOrNo(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Please make a valid selection.");
                            }
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                    } while (learn2 == true);
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