using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    class Inputs
    {
        private static double arguement1 = 0;
        private static double arguement2 = 0;
        private static string arguement1String = "";
        private static string arguement2String = "";
        private static string currentArguement = "";
        private static char operation = '0';
        private static bool arguement2Added = false;


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
            arguement1String = "";
            arguement2 = 0;
            arguement2String = "";
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
            if (operation.Equals('0'))
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
                //arguement2String = currentArguement;
                arguement2 = ParseStringToDouble(currentArguement);
                return CheckIsNaN(arguement2);
            }
        }
    }
}
