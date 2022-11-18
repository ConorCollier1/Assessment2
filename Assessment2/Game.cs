using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Game
    {
        static int gamesPlayed = 0;
        static int wins = 0;
        static int draws = 0;
        static int losses = 0;

        public static void PlayGame()
        {
            string playAgain = "";
            do
            {
                gamesPlayed++;
                //create players
                Player player1 = new Player();
                Player dealer = new Player();

                //allow user to enter their name
                Console.Write("Enter player name : ");
                player1.Name = Console.ReadLine();
                dealer.Name = "Dealer";

                //create and shuffle deck
                Deck deck1 = new Deck();
                deck1.ShuffleDeck();

                //player turn
                Console.WriteLine($"\n{player1.Name}'s turn");
                // Player gets 2 cards to start
                Console.WriteLine($"Card Dealt is the {deck1.DealCard(ref player1)}");
                Console.WriteLine($"Card Dealt is the {deck1.DealCard(ref player1)}");
                CheckForAce(player1);
                OutputPoints(player1);
                CheckPoints(player1);
                bool underTwentyOne = true;
                string stick_twist = "";

                do
                {
                    Console.Write("Do you want to stick or twist - (s/t)?");
                    stick_twist = Console.ReadLine().ToLower();

                    if (stick_twist == "t")//if user selects twist -- give them another card
                    {
                        Console.WriteLine($"\n{player1.Name}'s cards in hand are");//display cards player has
                        for (int i = 0; i < player1.NumCardsInHand; i++)//loop through cards in players hand 
                        {
                            Console.WriteLine($"The {player1.hand[i]}"); //print all cards in hand
                        }
                            Console.WriteLine($"New Card Dealt is the {deck1.DealCard(ref player1)}");
                        CheckForAce(player1);
                        OutputPoints(player1);
                        underTwentyOne = CheckPoints(player1);
                        
                        if(underTwentyOne==false)
                        {
                            Console.WriteLine($"****** {player1.Name} - Bust ******"); ///if player bust print message
                        }
                    }
                } while (underTwentyOne == true && stick_twist != "s");

                //if user does not go bust and choses to stick -- dealer plays
                if (underTwentyOne == true)
                {
                    bool dealerUnder = true; //dealer points under 21
                    
                    Console.WriteLine($"\n{dealer.Name}'s turn");
                    Console.WriteLine($"Card Dealt is the {deck1.DealCard(ref dealer)}");
                    Console.WriteLine($"Card Dealt is the {deck1.DealCard(ref dealer)}");
                    CheckForAce(dealer);
                    OutputPoints(dealer);
                    CheckPoints(dealer);

                    //If he has less than 17 he takes another card and repeats until he has 17 or more or is bust
                    do
                    {
                        if (dealer.Points < 17)
                        {
                            Console.WriteLine($"New Card Dealt is the {deck1.DealCard(ref dealer)}");
                            CheckForAce(dealer);
                            OutputPoints(dealer);
                            dealerUnder = CheckPoints(dealer);

                            if (dealerUnder == false)
                            {
                                Console.WriteLine($"****** {dealer.Name} - Bust ******"); //if dealer bust print message
                            }
                        }                   
                    }while (dealerUnder == true&&dealer.Points<17);

                }
                OutputWinner(player1, dealer);

                Console.Write("Do you want to play again? y/n ");
                playAgain = Console.ReadLine().ToLower();
                Console.WriteLine("");
            } while (playAgain == "y");

            OutputStats();
        }

        //method returns if player is still in the game or not
        static public bool CheckPoints(Player player)
        {
            if (player.Points > 21)
            {
                return false; //if over 21 -- bust
            }
            else
            {
                return true; //if player is under 21 they are still in the game
            }
        }

        //method to display the current points of the player
        static public void OutputPoints(Player player)            //outputs players current cards and point total
        {
            Console.WriteLine($"Current points : {player.Points}");
        }
        
        //method checks for aces and saves player from going bust if they have ace card
        static public void CheckForAce(Player player)  
        {
            bool aceToOnePoint = false;
            if (player.Points > 21) //check if player can be saved by an ace if they go over 21
            {
                for (int i = 0; i < player.NumCardsInHand; i++)//loop through cards in players hand
                {
                    if (player.hand[i].Points == 11 && aceToOnePoint == false)//if points equal 11 then card is ace
                    {
                        player.hand[i].Points = 1;          //change ace points from 11 to 1
                        player.Points -= 10;    //take 10 points from total
                        aceToOnePoint = true;
                    }
                }
            }
        }

        static public void OutputWinner(Player player, Player dealer)
        {
            bool playerAlive=CheckPoints(player);
            bool dealerAlive = CheckPoints(dealer);

            if(playerAlive==true && dealerAlive==true) //if both players are alive
            {
                if (player.Points>dealer.Points)
                {
                    Console.WriteLine($"\n{player.Name} Wins!\n");
                    wins++;
                }
                else if (dealer.Points == player.Points)
                {
                    Console.WriteLine("\nDraw!\n");
                   draws++;
                }
                else if (player.Points < dealer.Points)
                {
                    Console.WriteLine($"\n{dealer.Name} wins\n");
                    losses++;
                }
            }
            else if(playerAlive == true && dealerAlive == false)//if dealer is over 21 and player is not, player wins
            {
                Console.WriteLine($"\n{player.Name} Wins!\n");
                wins++;
            }
            else if (playerAlive == false && dealerAlive == true)
            {
                Console.WriteLine($"\n{dealer.Name} wins\n");
                losses++;
            }
        }
        
        //method to print results of all games played once user is finished playing
        static public void OutputStats()
        {
            Console.WriteLine("\n******Games Results******");
            Console.WriteLine($"Games Played : {gamesPlayed}");                                             //additional feature
            Console.WriteLine($"Player Wins : {wins}");
            Console.WriteLine($"Draws : {draws}");
            Console.WriteLine($"Player Losses : {losses}");
        }
    }
}
