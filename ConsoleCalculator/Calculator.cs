using System;
//using Operation;

namespace ConsoleCalculator
{
    public class Calculator
    {
        double arguement1 = 0;
        string arguement1String = "";
        char operation = '0';
        double arguement2 = 0;
        string arguement2String = "";
        double result = 0;
        bool arguement2Added = false;


        // Function to reset the calculator to default values
        


        public string SendKeyPress(char key)
        {
            // Add your implementation here.

            // Condition to input the values of Arguements
            if((key >= 48 && key <= 57) || key == '.')
            {

                return Inputs.StringInputToArguements(key);
               
                
            }
            else if(key == '=')
            {
                if (!arguement2Added)
                {
                    arguement2 = arguement1;
                }
                result = Operations.Operation(arguement1, arguement2, operation);
                
                resetCalculator();

                if (Double.IsNaN(result) || Double.IsInfinity(result))
                {
                    return "-E-";
                }
                else
                {
                    return (result).ToString();
                }
            }

            // Resetting the calculator
            else if (key == 'C' || key == 'c')
            {
                resetCalculator();
                return "0";
            }

            // Toggling the sign of arguements
            else if (key == 's' || key == 'S') {
                if(operation == '0')
                {
                    arguement1 *= -1;
                    return (arguement1).ToString();
                }
                else
                {
                    arguement2 *= -1;
                    return (arguement2).ToString();
                }
            }

            else 
            {
                // If already 2 arguements have been inputted
                if(operation != '0')
                {
                    double temp = Operations.Operation(arguement1, arguement2, operation);
                    resetCalculator();
                    arguement1 = temp;
                    arguement1String = arguement1.ToString();
                    // If output is Not a Number then give error;
                    if (Double.IsNaN(arguement1))
                    {
                        resetCalculator();
                        return "-E-";
                    }
                }

               if(key == '+')
                {
                    operation = '+';
                }
               else if(key == '-')
                {
                    operation = '-';
                }
               else if(key == 'x')
                {
                    operation = '*';
                }
               else if(key == '/')
                {
                    operation = '/';
                }
                return arguement1.ToString();
            }
        }
    }
}
