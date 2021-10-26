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
        public static List<Record> OrderByBubble(List<Record> records)
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

        public static List<Record> OrderByLinQ(List<Record> records)
        {
            return records.OrderByDescending(x => x.Date).ToList();
        }
    }
}
