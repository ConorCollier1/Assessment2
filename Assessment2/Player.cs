using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Player
    {
        public PlayingCard[] hand;  //create player hand
        public int Points { get; set; }
        public int NumCardsInHand { get; set; }
        public string Name { get; set; }

        public Player()
        {
            hand = new PlayingCard[10];  //i set so player can have at most 10 cards per game which will never be reached
        }
    }
}
