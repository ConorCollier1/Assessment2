using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Player
    {
        public PlayingCard[] hand;
        public int points;
        public int numCardsInHand;
        public string name;

        public Player()
        {
            hand = new PlayingCard[10];
            numCardsInHand = 0;
            points = 0;
        }
    }
}
