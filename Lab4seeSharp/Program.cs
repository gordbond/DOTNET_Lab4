/// <summary>
/// Gord Bond - 000786196
/// Nov. 12, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. No other person's work 
/// has been used without due acknowledgement.
/// 
/// Updates:
/// This app was updated to include the use of lambda expressions for the sort methods as well as
/// a List rather than an array.
/// 
/// 
/// Original
/// Console application used to read, and sort information from a .txt file
/// Specifically, the program reads the employees.txt file and sorts the information using 
/// an "insertion sort" based on either the Employee's name, number, pay rate, hours or gross pay. 
/// The program then displays this information to the user in an organized table.
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Lab4seeSharp
{
    class Program 
    {
        /// <summary>
        /// Main method used to run the "View" for Lab1 program. 
        /// This view includes printing a menu to the console, printing sorted 
        /// information about the employees in an organized table,
        /// as well as printing an error information necessary.
        /// </summary>
        /// <param name="args">command line arguments</param>
        static void Main(string[] args)
        {
            //Calls Read method using the information from "employees.txt" 
            //to populate the List of Employee objects called employeeList
            List<Employee> employeeList = Read("employees.txt");
            bool isRunning = true;

            while (isRunning)
            {
                //Clear is used to keep the menu at the top of the console
                Console.Clear();
                //Writes the Menu for the app
                Console.WriteLine(
                    "M E N U\n=======\n\n" +
                    "1. Sort by Employee Name (ascending)\n" +
                    "2. Sort by Employee Number (ascending)\n" +
                    "3. Sort by Employee Pay Rate (descending)\n" +
                    "4. Sort by Employee Hours (descending)\n" +
                    "5. Sort by Employee Gross Pay (descending)\n" +
                    "6. Exit \n\n" +
                    "Enter option:"
                    );
                try
                {
                    //parses string input by user into int then assigns it to variable option.
                    int option = int.Parse(Console.ReadLine());
                    //Switch case used to select the appropriate actions in response to user's input(option)
                    switch (option)
                    {
                        //Case one displays a table sorted by Employee name in ascending order.
                        case 1:
                            //calls Sort method using employeeList list and the 1 option 
                            //(for sorting by name/ascending) as the parameters
                            //**Updated  for lab 4 to include a lambda expression
                            employeeList.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
                            //Writes table headers to console
                            Console.WriteLine(
                                        String.Format("{0,-14}", "NAME") +
                                        String.Format("{0,-19}", "EMPLOYEE ID") +
                                        String.Format("{0,-14}", "HOURS") +
                                        String.Format("{0,-14}", "PAY RATE") +
                                        String.Format("{0,-8}", "GROSS PAY") + "\n");

                            //foreach loop which writes the employee infromation in an organized and formatted table
                            foreach (Employee e in employeeList)
                            {
                                Console.WriteLine(
                                    String.Format("{0,-17}", e.Name) +
                                    String.Format("{0,-14}", e.Number) +
                                    String.Format("{0,-16}", e.Hours + " hrs") +
                                    "$" + String.Format("{0,-14}", e.Rate) +
                                    "$" + String.Format("{0,-8}", e.GetGross()));
                            }
                            //reads line so that the Clear function doesn't immediately remove the employee data.
                            Console.ReadLine();

                            break;
                        //Case two displays a table sorted by Employee number in ascending order.
                        case 2:
                            //calls Sort method using employeeList List and the 2 option 
                            //(for sorting by number/ascending) as the parameters
                            //**Updated  for lab 4 to include a lambda expression
                            employeeList.Sort((emp1, emp2) => emp1.Number.CompareTo(emp2.Number));
                            //Writes table headers to console
                            Console.WriteLine(
                                         String.Format("{0,-14}", "NAME") +
                                         String.Format("{0,-19}", "EMPLOYEE ID") +
                                         String.Format("{0,-14}", "HOURS") +
                                         String.Format("{0,-14}", "PAY RATE") +
                                         String.Format("{0,-8}", "GROSS PAY") + "\n");

                            //foreach loop which writes the employee infromation in an organized and formatted table
                            foreach (Employee e in employeeList)
                            {
                                Console.WriteLine(
                                    String.Format("{0,-17}", e.Name) +
                                    String.Format("{0,-14}", e.Number) +
                                    String.Format("{0,-16}", e.Hours + " hrs") +
                                    "$" + String.Format("{0,-14}", e.Rate) +
                                    "$" + String.Format("{0,-8}", e.GetGross()));
                            }
                            Console.ReadLine();
                            break;
                        //Case three displays a table sorted by Employee pay rate in descending order.
                        case 3:
                            //calls Sort method using employeeList List and the 3 option 
                            //(for sorting by pay rate/descending) as the parameters
                            //**Updated  for lab 4 to include a lambda expression
                            employeeList.Sort((emp1, emp2) => emp2.Rate.CompareTo(emp1.Rate));
                            //Writes table headers to console
                            Console.WriteLine(
                                         String.Format("{0,-14}", "NAME") +
                                         String.Format("{0,-19}", "EMPLOYEE ID") +
                                         String.Format("{0,-14}", "HOURS") +
                                         String.Format("{0,-14}", "PAY RATE") +
                                         String.Format("{0,-8}", "GROSS PAY") + "\n");

                            //foreach loop which writes the employee infromation in an organized and formatted table
                            foreach (Employee e in employeeList)
                            {
                                Console.WriteLine(
                                    String.Format("{0,-17}", e.Name) +
                                    String.Format("{0,-14}", e.Number) +
                                    String.Format("{0,-16}", e.Hours + " hrs") +
                                    "$" + String.Format("{0,-14}", e.Rate) +
                                    "$" + String.Format("{0,-8}", e.GetGross()));
                            }
                            //reads line so that the Clear function doesn't immediately remove the employee data.
                            Console.ReadLine();


                            break;
                        //Case four displays a table sorted by Employee hours in descending order.
                        case 4:
                            //calls Sort method using employeeList List and the 4 option 
                            //(for sorting by hours/descending) as the parameters
                            //**Updated  for lab 4 to include a lambda expression
                            employeeList.Sort((emp1, emp2) => emp2.Hours.CompareTo(emp1.Hours));
                            //Writes table headers to console
                            Console.WriteLine(
                                         String.Format("{0,-14}", "NAME") +
                                         String.Format("{0,-19}", "EMPLOYEE ID") +
                                         String.Format("{0,-14}", "HOURS") +
                                         String.Format("{0,-14}", "PAY RATE") +
                                         String.Format("{0,-8}", "GROSS PAY") + "\n");

                            //foreach loop which writes the employee infromation in an organized and formatted table
                            foreach (Employee e in employeeList)
                            {
                                Console.WriteLine(
                                    String.Format("{0,-17}", e.Name) +
                                    String.Format("{0,-14}", e.Number) +
                                    String.Format("{0,-16}", e.Hours + " hrs") +
                                    "$" + String.Format("{0,-14}", e.Rate) +
                                    "$" + String.Format("{0,-8}", e.GetGross()));
                            }
                            Console.ReadLine();


                            break;
                        //Case five displays a table sorted by Employee gross pay in descending order.
                        case 5:
                            //calls Sort method using employeeList List and 
                            //the 5 option (for sorting by gross pay/descending) as the parameters
                            //**Updated  for lab 4 to include a lambda expression
                            employeeList.Sort((emp1, emp2) => emp2.GetGross().CompareTo(emp1.GetGross()));
                            //Writes table headers to console
                            Console.WriteLine(
                                         String.Format("{0,-14}", "NAME") +
                                         String.Format("{0,-19}", "EMPLOYEE ID") +
                                         String.Format("{0,-14}", "HOURS") +
                                         String.Format("{0,-14}", "PAY RATE") +
                                         String.Format("{0,-8}", "GROSS PAY") + "\n");

                            //foreach loop which writes the employee infromation in an organized and formatted table
                            foreach (Employee e in employeeList)
                            {
                                Console.WriteLine(
                                    String.Format("{0,-17}", e.Name) +
                                    String.Format("{0,-14}", e.Number) +
                                    String.Format("{0,-16}", e.Hours + " hrs") +
                                    "$" + String.Format("{0,-14}", e.Rate) +
                                    "$" + String.Format("{0,-8}", e.GetGross()));
                            }
                            Console.ReadLine();


                            break;
                        case 6:
                            //sets isRunning boolean flag to false thus closing the while loop and ending the program
                            isRunning = false;
                            break;
                        //default is called when an input outside of the menu items is input
                        default:
                            Console.WriteLine("You didn't enter a valid menu option. Please try again.");
                            Console.ReadLine();
                            break;
                    }

                }
                catch (System.FormatException)
                {//catches error if nothing is input and user presses enter.
                    Console.WriteLine("You didn't enter a valid menu option. Please try again.");
                    Console.ReadLine();
                }
            }

        }

        /// <summary>
        /// Read method accepts a string filename which is then read line by line 
        /// seperating each line into an List containing information such as
        /// name, hours, pay rate and employee number.
        /// This array is then used to create a new Employee object and 
        /// places it in an array of Employee objects then the array is returned.
        /// </summary>
        /// <param name="fileName">string containing the file name for a txt file</param>
        /// <returns></returns>
        public static List<Employee> Read(string fileName)
        {
            try
            {
                //create a new streamreader which is used to read the file from the parameters 
                StreamReader reader = new StreamReader(fileName);
                //create a new List of Employee objects which will accept up to 100 objects
                List<Employee> employeeList = new List<Employee>();
               
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    //splits the line of employee information by the comma and places it in the employee info List
                    string[] employeeInfo = line.Split(",");
                    employeeList.Add(new Employee(employeeInfo[0], int.Parse(employeeInfo[1]),
                        //creates new Employee object using employeeInfo List and assigns to employeeList List
                        decimal.Parse(employeeInfo[2]), double.Parse(employeeInfo[3])));
                }
               

                return employeeList;
            }
            //catch exceptions where file is not found
            catch (FileNotFoundException ex)
            {
                Console.Write($"File not found {fileName}");
                Console.ReadLine();
                return null;
            }
            //catches general exceptions
            catch (Exception ex)
            {//catches general exceptions
                Console.WriteLine($"Error Reading Data{ex.Message}");
                Console.ReadLine();
                return null;
            }
        }

    }
}
