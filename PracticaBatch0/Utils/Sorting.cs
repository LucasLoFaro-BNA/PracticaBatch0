using PracticaBatch0.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBatch0.Utils
{
    public static class Sorting
    {
        public enum SortingAlgoritm { Bubblesort, LinQ, Delegate }
        public static List<Record> SortDescending(List<Record> records)
        {
            switch (GetSortingAlgoritmFromConfig())
            {
                case SortingAlgoritm.Bubblesort:
                    return OrderByBubble(records);
                case SortingAlgoritm.LinQ:
                    return OrderByLinQ(records);
                case SortingAlgoritm.Delegate:
                    return OrderByDelegate(records);
                default:
                    return OrderByDelegate(records);
            }
        }
        

        private static List<Record> OrderByBubble(List<Record> records)
        {
            Record temp;
            for (int i = 0; i <= records.Count - 2; i++)
            {
                for (int j = 0; j <= records.Count - 2; j++)
                {
                    if (records[j].Date < records[j + 1].Date)
                    {
                        temp = records[j + 1];
                        records[j + 1] = records[j];
                        records[j] = temp;
                    }
                }
            }

            return records;
        }


        private static List<Record> OrderByLinQ(List<Record> records)
        {
            return records.OrderByDescending(x => x.Date).ToList();
        }


        private static List<Record> OrderByDelegate(List<Record> records)
        {
            records.Sort(
                delegate (Record a, Record b) 
                {
                    return b.Date.CompareTo(a.Date); 
                });
            return records;
        }


        private static SortingAlgoritm GetSortingAlgoritmFromConfig()
        {
            String setting = System.Configuration.ConfigurationManager.AppSettings["SortingAlgoritm"].ToLower();
            if (setting.Equals(SortingAlgoritm.Bubblesort.ToString().ToLower()))
                return SortingAlgoritm.Bubblesort;
            if (setting.Equals(SortingAlgoritm.LinQ.ToString().ToLower()))
                return SortingAlgoritm.LinQ;
            if (setting.Equals(SortingAlgoritm.Delegate.ToString().ToLower()))
                return SortingAlgoritm.Delegate;
            else
                throw new System.Configuration.ConfigurationErrorsException("Invalid Setting SortingAlgoritm.");
        }
    }
}
