/// <summary>
/// Gord Bond - 000786196
/// Nov. 12, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. No other person's work 
/// has been used without due acknowledgement.
/// 
/// Updates:
/// Employess was updated to use properties rather than instance variables where necessary
/// 
/// Original:
/// Console application used to read, and sort information from a .txt file
/// Specifically, the program reads the employees.txt file and sorts the information using 
/// an "insertion sort" based on either the Employee's name, number, pay rate, hours or gross pay. 
/// The program then displays this information to the user in an organized table.
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4seeSharp
{
    class Employee 
    {
        
        /// <summary>
        /// Property containing the employee's first and last name in a string
        /// </summary>
        public string Name { get; set; }
       
        /// <summary>
        /// Property containing employeee's identifcation number as a integer
        /// </summary>
        public int Number { get; set; }
       
        /// <summary>
        /// Property used to hold employee's hourly pay rate as a decimal
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Property used to hold employee's total hours worked as a double
        /// </summary>
        public double Hours { get; set; }

        // instance variable used to hold employee's gross pay as a decimal
        // gross pay is calculated by rate * hour plus time and a half for hours worked over 40
        private decimal gross;


        /// <summary>
        /// Constructor used to set the instance variables for the Employee object.
        /// Name, number, rate, hours and gross are all set in the constructor using the associated parameters.
        /// Gross is calculated using the parameters hour and rate
        /// </summary>
        /// <param name="name">Name is the employee's first and last name as a string.</param>
        /// <param name="number">Number is the employee's identification number for the company. It is a integer.</param>
        /// <param name="rate">Rate is the hour wage this employee makes as a decimal.</param>
        /// <param name="hours">Hours are the total number of hours worked by the employee as a double.</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            this.Name = name;
            this.Number = number;
            this.Rate = rate;
            this.Hours = hours;
            this.gross = GetGross();
        }
        /// <summary>
        /// Retrieves the private variable gross and rounds to 2 decimal places.
        /// </summary>
        /// <returns>Gross rounded to 2 decimal places. Return type is decimal.</returns>
        public decimal GetGross() {
            //Casts hours which is a double as a decimal. Sets the decimal of hours to new temp variable hoursDec.  
            //Decimal and double are not compatible for arthimatic operations
            decimal hoursDec = (decimal)Hours;
            //Calculates the Gross pay for the employee if there is no overtime. Gross is defined as Rate * Hours.
            if (hoursDec <= 40) { gross = Rate * hoursDec; }
            else
            {
                //Calculates the Gross pay if the employee works over 40 hours. 
                //Receives time and a half for hours worked over 40.
                decimal overtime = (hoursDec - 40) * (Rate * (decimal)1.5);
                gross = (Rate * 40) + overtime;//overtime + normal rate
            }
            return Math.Round(gross, 2);
        }

        /// <summary>
        /// ToString formatted to show each property
        /// </summary>
        /// <returns>a string representation of the object</returns>
        public override string ToString()
        {
            return "Gross: " + gross + ", Hours: " + Hours + ",  Name: " + Name +
                ", Number: " + Number + ", Rate: " + Rate;
        }

    }
}
