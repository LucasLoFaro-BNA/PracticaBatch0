using PracticaBatch0.Models;
using PracticaBatch0.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PracticaBatch0.UI
{
    public abstract class UserInterface
    {
        const int INPUT_LENGTH = 25;
        public enum DisplayFormat { ShortFormat, LongFormat }

        internal static (String,DisplayFormat) ProccessRuntimeArguments(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
                throw new ArgumentException("Invalid Arguments. Example: c:/temp/inputfile ShortFormat");

            if (!File.Exists(args[0]))
                throw new FileNotFoundException("Check input file.");

            if (args.Length == 1)
                return (args[0], DisplayFormat.LongFormat);

            if (args.Length == 2)
            {
                if (args[1].ToLower().Equals(UserInterface.DisplayFormat.ShortFormat.ToString().ToLower()))
                    return (args[0], DisplayFormat.ShortFormat);
                else if (args[1].ToLower().Equals(UserInterface.DisplayFormat.LongFormat.ToString().ToLower()))
                    return (args[0], DisplayFormat.LongFormat);
                else
                    throw new ArgumentException("Check DisplayFormat argument.");
            }
            return (args[0], DisplayFormat.LongFormat);
        }

        internal static List<Record> ProcessInput(string inputFilePath)
        {
            List<Record> Records = new List<Record>();
            String inputErrors = "";

            foreach (String line in File.ReadAllLines(inputFilePath))
            {
                if (line.Length == INPUT_LENGTH)
                    Records.Add(ParseInput(line));
                else
                    inputErrors += line + "\n";
            }
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
