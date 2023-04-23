using System;
namespace Assignment_2
{
    class SelectionAndIteration
    {
        public SelectionAndIteration()
        {
            Start();

        }
        public void Start()
        {

            Console.WriteLine();
            Console.WriteLine("My name is Olivia, I am a student of the Spring 22 semester!");
            Console.WriteLine();

            ShowStringLength();
            Console.WriteLine();

            MakeMyDay();
            Console.WriteLine();

            SumNumbers();
        }


        public void ShowStringLength()
        {
            string text = string.Empty; //same as ""
            bool done = false;

            Console.WriteLine("Let me calculate the length of strings for you!");
            do
            {
                Console.WriteLine("Give me a text of any length, or press enter to exit\n");
                text = Console.ReadLine();//text parameter for input text

                int length = text.Length; //see length of text as integer

                if (length == 0)
                    done = true;
                else
                    text = text.ToUpper();//turn to capitals

                Console.WriteLine("your text in capitals " + text);
                Console.WriteLine("the length of your text is " + length + " characters\n");
            } while (!done);
            Console.WriteLine("Ok you pressed enter, see you later!");
        }

        public void MakeMyDay()
        {
            Console.Write("I can predict your day for you.\n");
            Console.Write("Give a number between 1 and 7: ");
            int day = int.Parse(Console.ReadLine()); //input day nr as integer
            string fortune = string.Empty; //save fortunate p as string


            switch (day)
            {
                case 1:
                    fortune = "Monday:  keep calm! you can fall apart!";
                        break;
                case 2:
                case 3:
                    fortune = "Tuesday and Wednesday break your heart!";
                        break;
                case 4:
                    fortune = "Thursday, Uuush, still one day to Friday!";
                        break;
                case 5:
                    fortune = "It's Friday! You are in love!";
                        break;
                case 6:
                    fortune = "Saturday, do nothing and do plenty of it!";
                        break;
                case 7:
                    fortune = "And Sunday always comes too soon!";
                        break;
                default:
                    fortune = "Not in a good mode? This is not a valid date!";
                    break;

            }

            Console.WriteLine(fortune); //print fortune

         }
            

            private int SumNumbers(int start, int end) //calculation for SumNumbers

            {
                int sum = 0;
                for (int i = start; i <= end; i++)
                {
                    sum = sum + i;
                }
                return sum;
            }

        public void SumNumbers()
        {
            Console.WriteLine();
            Console.Title = "sums nrs between any two numbers";
            Console.Write("Give start number: ");

            int startNum = int.Parse(Console.ReadLine()); //read in startnum as int

            Console.WriteLine();
            Console.Write("Give end number: ");
            int endNum = int.Parse(Console.ReadLine()); //read in end number as int

            Console.WriteLine(startNum);
            Console.WriteLine(endNum);

            int startNum2 = startNum; //saved starnum as int parameter
            if (startNum2 > endNum) //rearrange if startnum is larger than end nr
            {
                startNum = endNum;
                endNum = startNum2;
                }
             int sum = SumNumbers(startNum, endNum);


            Console.WriteLine("the sum of the numbers between " + startNum + " and " + endNum + " is " + sum);

            }
        }
    }
