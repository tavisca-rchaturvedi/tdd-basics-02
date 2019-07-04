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
        private static char operation = '0';
        private static bool arguement2Added = false;


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
            if (Double.IsNaN(arguement))
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

            // If operation is not yet given, means still arguement 1 inputted
            if (operation.Equals('0'))
            {
                // if '.' is pressed then check if last value was also a '.'
                // Input only if the last value is not a '.'
                // Else give an error

                if (key == '.')
                {
                    if (!arguement1String.EndsWith("."))
                        arguement1String += key;
                }
                else
                {
                    arguement1String += key;
                }

                arguement1 = ParseStringToDouble(arguement1String);

                return CheckIsNaN(arguement1);
                
            }
            else
            {
                arguement2Added = true;
                if (key == '.')
                {
                    if (!arguement2String.EndsWith("."))
                        arguement2String += key;
                }
                else
                {
                    arguement2String += key;
                }

                arguement2 = ParseStringToDouble(arguement2String);

                return CheckIsNaN(arguement2);
            }
        }
    }
}
