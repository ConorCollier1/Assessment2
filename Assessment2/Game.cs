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
        public static void PlayGame()
        {
            string playAgain = "";
            do
            {
                //create and shuffle deck
                Deck deck1 = new Deck();
                deck1.ShuffleDeck();

                //create players
                Player player1 = new Player();
                player1.name = "Player";
                Player dealer = new Player();
                dealer.name = "Dealer";

                //player turn
                Console.WriteLine("*** Player's Turn ***");
                // Draw the first two cards for the Player
                Console.WriteLine($"Card Dealt is {deck1.DealCard(ref player1)}");              
                Console.WriteLine($"Card Dealt is {deck1.DealCard(ref player1)}");
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
                        Console.WriteLine($"Card Dealt is {deck1.DealCard(ref player1)}");
                        CheckForAce(player1);
                        underTwentyOne = CheckPoints(player1);
                    }
                } while (underTwentyOne == true && stick_twist != "s");
                Console.Write("Do you want to play again? y/n ");
                playAgain = Console.ReadLine().ToLower();
                Console.WriteLine("\n");
            } while(playAgain=="y");
        }

        static public bool CheckPoints(Player player)
        {
            if (player.points > 21)
            {
                Console.WriteLine("Bust!");             //if over 21 -- bust
                return false;
            }

            return true;
        }

        static public void OutputPoints(Player player)            //outputs players current cards and point total
        {
            Console.WriteLine($"Current points: {player.points}");
        }
        static public void CheckForAce(Player player) //check for aces 
        {
            bool aceToOnePoint = false;
            if(player.points>21) //check if player can be saved by an ace if they go over 21
            {
                for(int i = 0; i < player.numCardsInHand; i++)//loop through cards in players hand
                {
                    if (player.hand[i].Points==11&&aceToOnePoint==false)//if points equal 11 then card is ace
                    {
                        player.hand[i].Points = 1;          //change ace points from 11 to 1
                        player.points -= 10;    //take 10 points from total
                        aceToOnePoint = true;
                    }
                }
            }
        }
    }
}
