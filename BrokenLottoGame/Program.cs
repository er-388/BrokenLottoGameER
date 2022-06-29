using System;
using System.Threading;

/* 
 * Exercise: 
 * Recognise parts that can throw an error
 * Modify the code and add error handling where needed  
 */


namespace BrokenLottoGame
{
    public class Raffle
    {
        public bool victory;
        public int guessedNumber;
        public int victoryNumber;
        public string[] price = new string[]
        {
            "Pony",
            "One million dollars",
            "Bike",
            "Hat",
            "Ice cream"
        };

        public void Welcome()
        {
            Console.WriteLine("\n\n*********************************");
            Console.WriteLine("Welcome to the lotto game\n");
        }

        static void ShowDots()
        {
            int i = 0;
            while (i < 3)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                i++;
            }
            Console.WriteLine("\n\n");
        }

        void GetResult()
        {
            var rand = new Random();
            victoryNumber = rand.Next(10);
            //victoryNumber = 7;//For testing prize string array with a large number.

            if (victoryNumber == guessedNumber)
            {
                victory = true;
            }
            else
            {
                victory = false;
            }
        }

        public void Play()
        {
            Console.WriteLine("Guess a number between 1-10:\n");
            try
            {
                guessedNumber = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Your guess wasn't in the right format.");
            }

            Console.Write("\nGood luck!\n\nRaffling ");
            ShowDots();
            GetResult();
        }
    }



    class Exercise
    {
        static void Main(string[] args)
        {
            Raffle lotto = new Raffle();

            lotto.Welcome();
            lotto.Play();

            if (lotto.victory)
            {
                try
                {
                    Console.Write(" Congratulations! You won ");
                    Console.Write(lotto.price[lotto.victoryNumber]);
                    Console.WriteLine("");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.Write("but your guess wasn't good enough for a price!\n");
                    Console.WriteLine("Error message: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine(" Correct number was " + lotto.victoryNumber + "\n You lost :(  No price for you\n");
            }

            Console.WriteLine("*********************************");

        }
    }
}