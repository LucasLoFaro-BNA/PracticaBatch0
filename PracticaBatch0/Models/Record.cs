using System;

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
        }
    }

}
