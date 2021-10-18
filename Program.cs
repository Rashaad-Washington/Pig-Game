using System;

//Rashaad Washington
//CSCI 3005
//Assignment 1

namespace Pig
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("=========== Welcome to Pig ===========\n");
            Console.WriteLine("= Developed by Rashaad H. Washington =\n");
            Console.WriteLine("= Oink Oink Oink Oink Oink Oink Oink =\n");
            Console.WriteLine("======================================\n");
            Game g = new Game();

            g.SetupDie();
            g.SetupMaxPoints();
            g.SetupPlayer1();
            g.SetupPlayer2();
            g.PlayGame();
            g.ShowWinner();
        }
    }
}
