using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Examples.Basics
{
    class AgeCalculator
    {


        // Authors: William Vickerage | 25815409
        // This code tells a user how long they have been alive for

        // This code prompts a user to input their name into the console which will be stored as a string.
        // The program will then ask the user for their date of birth in a specified format.
        // Then the current date and time is calculated to compute the time span between the current date and the inputted birthdate from the user.
        // The total days lived are divided by 365.25 to approximate the user's age in years, accounting for leap years too.
        // The program then calculates the number of days, hours, minutes, and seconds using properties of the timespan.



        public static void run()
        {

           Console.WriteLine("Please enter your name: "); // prompts user to enter their name
            string name = Console.ReadLine(); // reads and saves input

            while (string.IsNullOrWhiteSpace(name)) // checks if the input is empty or whitespace
            {
                Console.WriteLine("Name cannot be empty. Please enter your name:"); // prompts again for error handling
                name = Console.ReadLine(); // reads and saves input
            }

            Console.WriteLine("Please enter your date of birth (DD/MM/YYYY):"); // prompts user to enter their date of birth with this specified format
            DateTime birthDate; // variable to hold the parsed birth date
            while (true) // starts a while loop to ask for a valid date
            {
                string birthDateString = Console.ReadLine(); // read the date of birth input as a string
                if (DateTime.TryParseExact(birthDateString, "dd/MM/yyyy", null, DateTimeStyles.None, out birthDate)) // tries to parse the string into a dateTime object 
                {
                    if (birthDate > DateTime.Now) // checks if the parsed date is in the future
                    {
                        Console.WriteLine("Birth date cannot be in the future. Please enter a valid date of birth in the format DD/MM/YYYY."); // error handling for future date
                    }
                    else
                    {
                        break; // exits loop
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter your date of birth in the format DD/MM/YYYY."); // error handling for invalid format
                }
            }

            DateTime now = DateTime.Now; // gets current date and time
            TimeSpan ageSpan = now - birthDate; // calculates the time between now and birthdate 

            int years = (int)(ageSpan.TotalDays / 365.25); // number of years lived
            int daysLived = (int)ageSpan.TotalDays; // number of days lived
            int hoursLived = (int)ageSpan.TotalHours; // number of hours lived
            int minutesLived = (int)ageSpan.TotalMinutes; // number of minutes lived
            int secondsLived = (int)ageSpan.TotalSeconds; // number of seconds lived

            Console.WriteLine($"Hello {name}, you are {years} years old!"); // prints users name and age in years

            Console.WriteLine($"You have lived for approximately {daysLived} days, {hoursLived} hours, {minutesLived} minutes, and {secondsLived} seconds."); // prints days, hours, minutes and seconds lived

        }

    }
}
