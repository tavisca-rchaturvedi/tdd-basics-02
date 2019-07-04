using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Inputs
    {
        private static double arguement1 = 0;
        private static double arguement2 = 0;
        private static string currentArguement = "";
        private static bool arguement2Added = false;


        public static void CurrentArguementReset()
        {
            currentArguement = "";
            arguement2Added = true;
        }
        public static double[] GetArguements()
        {
            return new double[] { arguement1, arguement2 };
        }

        public static bool SecondArguementAdded()
        {
            return arguement2Added;
        }


        public static void resetCalculator()
        {
            arguement1 = 0;
            arguement2 = 0;
            operation = '0';
            arguement2Added = false;
        }

        public static double ParseStringToDouble(string arguement)
        {
            if (Double.TryParse(arguement, out double temporary))
            {
                return temporary;
            }
            else
            {
                return Double.NaN;
            }
        }

        public static string CheckIsNaN(double arguement)
        {
            if (Double.IsNaN(arguement) || Double.IsInfinity(arguement))
            {
                resetCalculator();
                return "-E-";
            }
            else
            {
                return arguement.ToString();
            }
        }

        public static double[] SignToggle(double parameter1, double parameter2)
        {
            arguement1 = parameter1;
            arguement2 = parameter2;
            _ = Inputs.SecondArguementAdded() ? arguement2 *= -1 : arguement1 *= -1;
            return new double[] { arguement1, arguement2 };
        }



        public static string StringInputToArguements(char key)
        {

            if (key == '.')
            {
                if (!currentArguement.EndsWith("."))
                    currentArguement += key;
            }
            else
            {
                currentArguement += key;
            }


            // If operation is not yet given, means still arguement 1 inputted
            if (!Inputs.SecondArguementAdded())
            {
                // if '.' is pressed then check if last value was also a '.'
                // Input only if the last value is not a '.'
                // Else give an error

                //arguement1String = currentArguement;
                
                arguement1 = ParseStringToDouble(currentArguement);
                return CheckIsNaN(arguement1);
                
            }
            else
            {
                arguement2Added = true;
                arguement2 = ParseStringToDouble(currentArguement);
                return CheckIsNaN(arguement2);
            }
        }
    }
}
