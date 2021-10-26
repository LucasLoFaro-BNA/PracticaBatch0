using PracticaBatch0.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaBatch0
{
    class Program
    {
        static void Main(string[] args)
        {
            (String inputFilePath, UserInterface.DisplayFormat DisplayFormat) = UserInterface.ProccessRuntimeArguments(args);
            UserInterface.PrintOutput(UserInterface.ProcessInput(inputFilePath), DisplayFormat);
        }
    }
}
