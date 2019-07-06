using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // declaring variables
            int playerScore = 0;
            int aiScore = 0;
            string aiChoice;
            string playerChoice;
            string playAgain = "yes";
            string[] choices = { "rock", "paper", "scissors" };
            string[] playerChoices = { "rock", "paper", "scissors", "r", "p", "s" };

            Console.WriteLine("Welcome! Type in (r)ock, (p)aper or (s)cissors.");

            // main loop, the game will run until player doesnt respond with "yes" or "y" 
            while (playAgain == "yes" || playAgain == "y")
            {
                aiChoice = AIChoice(choices);
                playerChoice = PlayerChoice(playerChoices);

                //ChoosingWinner method will return either 0 or 1 or 2. 0:ai wins, 1:player wins, 2:draw
                if (ChoosingWinner(playerChoice, aiChoice, choices) == 2)
                {
                    Console.WriteLine("\nYour choice: {0},  AI choice: {1}", playerChoice.ToUpper(), aiChoice.ToUpper());
                    Console.WriteLine("Draw;");
                    Console.WriteLine("Your score: {0},  AI score: {1}", playerScore, aiScore);
                    continue; 
                }
                else if (ChoosingWinner(playerChoice, aiChoice, choices) == 0)
                {
                    aiScore += 1;
                    Console.WriteLine("\nYour choice: {0},  AI choice: {1}", playerChoice.ToUpper(), aiChoice.ToUpper());
                    Console.WriteLine("\nYou lose.");
                }
                else
                {
                    playerScore += 1;
                    Console.WriteLine("\nYour choice: {0},  AI choice: {1}", playerChoice.ToUpper(), aiChoice.ToUpper());
                    Console.WriteLine("\nYou win!");
                }

                //This part just prints out the score and asks if player wants to play again
                Console.WriteLine("Your score: {0},  AI score: {1}", playerScore, aiScore);
                Console.Write("\n\nDo you want to play again? ");
                playAgain = Console.ReadLine();
            }
        }

        static string AIChoice(string[] array)
        {
            //this method will randomly generate choice for AI
            Random rnd = new Random();
            int rndChoice = rnd.Next(0, 3); 
            return array[rndChoice];
        }
        
        static string PlayerChoice(string[] array)
        {
            //while loop is there to make sure player enters valid input
            while (true)
            {
                Console.Write("\nEnter your choice: ");
                string playerChoice = Console.ReadLine();

                if (array.Contains(playerChoice))
                {
                    if (playerChoice == "r")
                    {
                        playerChoice = "rock";
                    }
                    else if (playerChoice == "p")
                    {
                       playerChoice = "paper";
                    }
                    else if (playerChoice == "s")
                    {
                        playerChoice = "scissors";
                    }

                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        } 

        static int ChoosingWinner(string playerChoice, string aiChoice, string[] arr)
        {
            //basic logic behind who wins or who loses. I tried to think of something more elegant than if/else, couldnt think of anything. maybe later
            if (Array.IndexOf(arr, playerChoice) == Array.IndexOf(arr, aiChoice))
            {
                return 2;
            }
            else if (playerChoice == "rock" && aiChoice == "scissors")
            {
                return 1;   
            }
            else if (playerChoice == "rock" && aiChoice == "paper")
            {
                return 0;
            }
            else if (playerChoice == "scissors" && aiChoice == "rock")
            {
                return 0; 
            }
            else if (playerChoice == "scissors" && aiChoice == "paper")
            {
                return 1; 
            }
            else if (playerChoice == "paper" && aiChoice == "rock")
            {
                return 1;  
            }
            else if (playerChoice == "paper" && aiChoice == "scissors")
            {
                return 0;              
            }
           
            // I was getting error "not all code paths return int" so I had to put something here
            return -1;         
        }
    }
}
