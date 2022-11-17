using System;
using System.Collections.Generic;
using System.Linq;
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

                Console.WriteLine(deck1.DealCard());
                Console.WriteLine(deck1.DealCard());
            }while(playAgain=="Y");
        }
    }
}
