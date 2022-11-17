using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class PlayingCard
    {
        private string Value;
        private string Suit;
        public int Points;

        public PlayingCard(string value, string suit)
        {
            Value = value;
            Suit = suit;

                if (Value == "Jack" || Value == "Queen" || Value == "King")//if its a face card set points to 10
                {
                    Points = 10;
                }
                else if (Value == "Ace") // If it's an ace set points to 11
                {
                    Points = 11;
                }
                else
                {
                    Points = Convert.ToInt32(Value);
                }
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
