using PracticaBatch0.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PracticaBatch0.UI
{
    public abstract class UserInterface
    {
        const int INPUT_LENGTH = 25;
        internal static Record ProcessInput()
        {
            Console.WriteLine("Enter the record:");
            return ParseInput(Console.ReadLine());
        }

        private static Record ParseInput(string input)
        {
            Console.WriteLine("\n\tProcessing record: " + input);
            if (input.Length != INPUT_LENGTH)
                throw new ApplicationException("Invalid input. Must be 25 characters");

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

        internal static bool PrintOutput(Record record)
        {

            String output = @"
                Fecha del registro: " + record.Date.ToString("yyyy/MM/dd") + "\n\t\t" +
                @"Hora del registro: " + record.Date.Hour.ToString() + " Hs " +
                                         record.Date.Minute.ToString() + " Min " +
                                         record.Date.Second.ToString() + " Seg" + "\n\t\t" +
                @"Temperatura: " + record.Temperature.ToString().Replace(".", ",") + "°" + "\n\t\t" +
                @"Humedad: " + record.Humidity.ToString().Replace(".", ",") + "%" + "\n\t\t" +
                @"Codigo: “" + record.SensorID + "“" + "\n\t\t" +
                @"Activo: " + ((record.SensorStatus) ? "SI" : "NO");

            Console.WriteLine(output);
            Console.ReadKey();
            return true;
        }
    }
}
