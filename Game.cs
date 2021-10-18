using System;

//Rashaad Washington
//CSCI 3005
//Assignment 1

namespace Pig
{
    // Represents a single die
    class Game
    {
        Die gameDie;
        Player player1;
        Player player2;
        int maxPoints;

        public Game()
        {
            gameDie = null;
            player1 = null;
            player2 = null;
            maxPoints = 0;
        }
        public void SetupDie()
        {
            int sides;
            do
            {
                Console.Write("How many sides on the die (4 - 20): ");
                sides = Convert.ToInt32(Console.ReadLine());
                if (sides < 4 || sides > 20)
                {
                    Console.WriteLine($"WARNING: {sides} is not a valid value. Please try again.");
                } else
                {
                    gameDie = new Die(sides);
                }
            } while (sides < 4 || sides > 20);
        }
        
        public void SetupMaxPoints()
        {
            int points;
            do
            {
                Console.Write("What are the max points for the game: ");
                points = Convert.ToInt32(Console.ReadLine());
                if (maxPoints < 0)
                {
                    Console.WriteLine($"WARNING: {points} is not a valid value. Please try again.");
                } else
                {
                    maxPoints = points;
                }
            } while (maxPoints < 0);
        }
        public void SetupPlayer1()
        {
            string input;
            do
            {
                Console.Write("What is player 1's name: ");
                input = Console.ReadLine();
                if (input == "" || input == null)
                {
                    Console.WriteLine($"WARNING: {input} is not a valid name. Please try again.");
                }
                else
                {
                    player1 = new Player(input);
                }
            } while (input == "" || input == null);
        }
        public void SetupPlayer2()
        {
            string input;
            do
            {
                Console.Write("What is player 2's name: ");
                input = Console.ReadLine();
                if (input == "" || input == null)
                {
                    Console.WriteLine($"WARNING: {input} is not a valid name. Please try again.");
                }
                else
                {
                    player2 = new Player(input);
                }
            } while (input == "" || input == null);
        
        }
        public void PlayGame()
        {
            int game = 0;
            int input;
            int turn = 1;
            do
            {
                switch(turn)
                {
                    case 1:
                        input = 1;
                        turn = 2;
                        Console.WriteLine($"\nCurrent player: {player1}");
                        Console.WriteLine($"Current score: {player1.GetScore()}\n");
                        int score1 = player1.GetScore();
                        do
                        {
                            gameDie.roll();
                            Console.WriteLine($"You rolled a {gameDie.GetCurrentValue()}"); 
                            if (gameDie.GetCurrentValue() == 1)
                            {
                                Console.WriteLine("Sorry, you rolled a 1. Your turn is over.");
                                player1.SetScore(score1);
                                Console.WriteLine("\n");
                                break;
                            }
                            else
                            {
                                do
                                {
                                    Console.Write("Do you want to roll or hold (1=roll, 2=hold): ");
                                    input = Convert.ToInt32(Console.ReadLine());
                                } while (input != 1 && input != 2);
                                player1.SetScore(player1.GetScore() + gameDie.GetCurrentValue());
                            }
                        } while (input == 1);
                        break;

                    case 2:
                        Console.WriteLine($"{player1}'s score is now {player1.GetScore()}");
                        Console.WriteLine("\n------------------ Next player's turn ------------------");
                        turn = 3;
                        game = player1.GetScore();
                        break;

              //-------------------------------------------------------------------------------

                    case 3:
                        input = 1;
                        turn = 4;
                        Console.WriteLine($"Current player: {player2}\n");
                        Console.WriteLine($"Current score: {player2.GetScore()}\n");
                        int score2 = player2.GetScore();
                        do
                        {
                            gameDie.roll();
                            Console.WriteLine($"You rolled a {gameDie.GetCurrentValue()}\n"); //debug
                            if (gameDie.GetCurrentValue() == 1)
                            {
                                Console.WriteLine("Sorry, you rolled a 1. Your turn is over.");
                                player2.SetScore(score2);
                                Console.WriteLine("\n");
                                break;
                            }
                            else
                            {
                                do
                                {
                                    Console.Write("Do you want to roll or hold (1=roll, 2=hold): ");
                                    input = Convert.ToInt32(Console.ReadLine());
                                } while (input != 1 && input != 2);
                                player2.SetScore(player2.GetScore() + gameDie.GetCurrentValue());
                            }
                        } while (input == 1);
                        break;

                    case 4:
                        Console.WriteLine($"{player2}'s score is now {player2.GetScore()}");
                        Console.WriteLine("\n------------------ Next player's turn ------------------");
                        turn = 1;
                        game = player2.GetScore();
                        break;

                }
            } while (game < maxPoints);
        }
        public void ShowWinner()
        {
            Console.WriteLine("\n------------- Winner Winner Chicken Dinner -------------\n");

            if (player1.GetScore() > player2.GetScore())
            {
                player1.SetWinner(true);
                Console.WriteLine($"Player 1, {player1}, is the winner with {player1.GetScore()} points!");
            }
            else if (player1.GetScore() < player2.GetScore())
            {
                player2.SetWinner(true);
                Console.WriteLine($"Player 2, {player2}, is the winner with {player2.GetScore()} points!");
            }
        }
    }

    // Represents a single player in the game
    class Player
    {
        string name;
        int score;
        bool winner;

        public Player(string name)
        {
            this.name = name;
            if (name == null)
            {
                throw new ArgumentException($"{name} is not a valid name");
            }
            score = 0;
            winner = false;
        }

        public string GetName() { return name; }
        public int GetScore() {
            return score; }
        public bool IsWinner() { return winner; }
        public void SetScore(int score)
        {
                this.score = score;
        }
        public void SetWinner(bool winner)
        {
            this.winner = winner;
        }
        public override string ToString()
        {
            return name;
        }

    }

    // Class Die manages the die and the players of the game,
    // and contains the logic for the game
    class Die 
    {
        private int numSides;
        private int currentValue;
        Random rand;

        public Die(int numSides)
        {
            this.numSides = numSides;
            if (numSides < 4 || numSides > 20)
            {
                throw new ArgumentException($"{numSides} is not a value between 4-20");
            }
            currentValue = 1;
            rand = new Random();
        }

        public void roll()
        {
            currentValue = rand.Next(1, numSides);
        }

        public int GetCurrentValue()
        {
            return currentValue;
        }
    }
}
