using System;
using System.Collections.Generic;

namespace PracticaBatch0.Models
{
    public class Record
    {
        public DateTime Date { get; set; }
        public Double Temperature { get; set; }
        public Double Humidity { get; set; }
        public String SensorID { get; set; }
        public Boolean SensorStatus { get; set; }

        public Record(DateTime date, Double temperature, Double humidity, String sensorID, Boolean sensorStatus)
        {
            this.Date = date;
            this.SensorID = sensorID;
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.SensorStatus = sensorStatus;

            if (!(this.isValid()))
                Console.WriteLine("Invalid Record.");
        }

        private bool isValid()
        {
            if (Date.Year < 1900)           //Ejemplos de validaciones en el modelo (no lo dice el enunciado)
                return false;
            if (Humidity <= 5)
                return false;

            return true;
        }

        public String ToString(UI.UserInterface.DisplayFormat displayFormat)
        {
            String output = "";
            if (displayFormat == UI.UserInterface.DisplayFormat.ShortFormat)
            {
                output += "\n\t\tFecha/Hora registro: " + Date.ToString() + "\n\t\t";
            }
            else
            {
                output += "\n\t\tFecha del registro: " + Date.ToString("yyyy/MM/dd") + "\n\t\t" +
                                @"Hora del registro: " + Date.Hour.ToString() + " Hs " +
                                                         Date.Minute.ToString() + " Min " +
                                                         Date.Second.ToString() + " Seg" + "\n\t\t";
            }
            output += @"Temperatura: " + Temperature.ToString().Replace(".", ",") + "°" + "\n\t\t" +
                      @"Humedad: " + Humidity.ToString().Replace(".", ",") + "%" + "\n\t\t" +
                      @"Codigo: “" + SensorID + "“" + "\n\t\t" +
                      @"Activo: " + ((SensorStatus) ? "SI" : "NO");

            return output;
        }

        public List<Record> OrderByBubble (List<Record> records)
        {
            Record temp;
            for (int i = 0; i <= records.Count - 2; i++)
            {
                for (int j = 0; j <= records.Count - 2; j++)
                {
                    if (records[j].Date > records[j + 1].Date)
                    {
                        temp = records[j + 1];
                        records[j + 1] = records[j];
                        records[j] = temp;
                    }
                }
            }

            return records;
        }
    }
}
