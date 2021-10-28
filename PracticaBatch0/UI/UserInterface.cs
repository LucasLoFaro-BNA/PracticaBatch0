using PracticaBatch0.Models;
using PracticaBatch0.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PracticaBatch0.UI
{
    public abstract class UserInterface
    {
        const int INPUT_LENGTH = 25;
        public enum DisplayFormat { ShortFormat, LongFormat }

        internal static DisplayFormat ProccessRuntimeArguments(string[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException("Must enter Display Format argument. (ShortFormat or LongFormat)");

            if (args[0].ToLower().Equals(UserInterface.DisplayFormat.ShortFormat.ToString().ToLower()))
                return DisplayFormat.ShortFormat;
            else if (args[0].ToLower().Equals(UserInterface.DisplayFormat.LongFormat.ToString().ToLower()))
                return DisplayFormat.LongFormat;
            else
                throw new ArgumentException("Check execution arguments.");
        }

        internal static List<Record> ProcessInput()
        {
            List<Record> Records = new List<Record>();
            String inputErrors = "";
            String input;

            Console.WriteLine("Enter the list of records:");
            do
            {
                input = Console.ReadLine();
                if (input.Length == INPUT_LENGTH)
                    Records.Add(ParseInput(input));
                else
                    inputErrors += input + "\n";
            } while (input.Length != 0);

            if (inputErrors.Length > 0)
                Console.WriteLine("The following records were not processed due to format errors: \n" + inputErrors);

            return Records;
        }

        private static Record ParseInput(string input)
        {
            Console.WriteLine("\n\tProcessing record: " + input);
            try
            {
                DateTime Date = DateTime.ParseExact(input.Substring(0, 14), "yyyyMMddHHmmss", new CultureInfo("es-AR"));
                Double Temperature = Convert.ToInt32(input.Substring(14, 3)) / 10;
                Double Humidity = Convert.ToDouble(input.Substring(17, 3)) / 10;
                String SensorID = input.Substring(20, 4);
                Boolean SensorStatus = Convert.ToBoolean(Convert.ToInt32(input.Substring(24, 1)));

                return new Record(Date, Temperature, Humidity, SensorID, SensorStatus);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Invalid input. Check fields validations" + ex);
            }
        }

        internal static bool PrintOutput(List<Record> records, DisplayFormat displayFormat)
        {
            Console.WriteLine("Records proccessed OK. \n\n");

            foreach (var record in Sorting.SortDescending(records))
                Console.WriteLine(record.ToString(displayFormat));

            Console.ReadKey();
            return true;
        }
    }
}
