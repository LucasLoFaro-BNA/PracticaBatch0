using PracticaBatch0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBatch0.Utils
{
    public static class Sorting
    {
        public enum SortingType { Bublesort, LinQ, Delegate }
        public static List<Record> SortDescending(List<Record> records)
        {
            SortingType algoritm = SortingType.Bublesort;

            switch (algoritm){
                case SortingType.Bublesort:
                        return OrderByBubble(records);
                case SortingType.LinQ:
                        return OrderByLinQ(records);
                case SortingType.Delegate:
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


    }
}
