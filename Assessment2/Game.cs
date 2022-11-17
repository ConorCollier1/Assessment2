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
                Console.WriteLine($"Card Dealt is {deck1.DealCard(player1)}");
                Console.WriteLine($"Card Dealt is {deck1.DealCard(player1)}");
                OutputPoints(player1);
            } while(playAgain=="Y");
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
    }
}
