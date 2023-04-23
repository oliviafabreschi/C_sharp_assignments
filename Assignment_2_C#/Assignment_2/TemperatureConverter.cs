using System;
namespace Assignment_2
{
    class TemperatureConverter
    {

        public TemperatureConverter()
        {
            //clear console
            Console.Clear();
           Start();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Welcome to Temperature Converter");
            Console.WriteLine("\nCelsius to Farenheit: 1 \nFarenheit to Celsius: 2 \nExit: 0");
            Console.WriteLine("Your choice: ");
            //int choice = int.Parse(Console.ReadLine());
            //show menu and do calculations
        }

        public void Start()
        {
            int choice = -1; //invalid option
            while (choice != 0)
            {
                ShowMenu();
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        //do nothing, exit loop
                        break;
                    case 1:
                        ShowTableCelsiusToFarenheit();
                        break;
                    case 2:
                        ShowTableFarenheitToCelsius();
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again!");
                        break;

                }
            }

        }

        private void ShowTableCelsiusToFarenheit()
        {
            const int columns = 2;

            const int max = 100;
            int p = 0;
            for (int i = 0; i <= max; i += 4)
            {
                double result = CelsiusToFarenheit(i);
                Console.Write("{0,6:f2} C = {1,6:f2} F ", i, result);

                p++;
                if ((p % columns == 0) && (p >= columns))
                    Console.WriteLine();
            }
        }

        private double CelsiusToFarenheit(double celsius)
        {
            return 9.0 / 5.0 * celsius + 32.0;
        }


        private void ShowTableFarenheitToCelsius()
        {
            const int columns = 2;

            const int max = 212;

            int p = 0;
            for (int i = 0; i <= max; i += 4)
            {
                double result = FarenheitToCelsius(i);
                Console.Write("{0,6:f2}F = {1,6:f2}C ", i, result);


                p++;
                if ((p % columns == 0) && (p >= columns))
                    Console.WriteLine();
            }
        }
        private double FarenheitToCelsius(double farenheit)
        {
            return ((farenheit - 32.0) * 5.0)/ 9.0;

        }


       
    }
}

