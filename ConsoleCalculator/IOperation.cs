using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    interface IOperation
    {
        double Calculate(double arguement1, double arguement2);
    }
}
