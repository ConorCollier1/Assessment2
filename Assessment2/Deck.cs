using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    internal class Deck
    {
        private PlayingCard[] deck;
        private int card;
        private const int deckSize = 52;
        private Random randomNumber=new Random();
        public int Points;

        public Deck()
        {
            //create card arrays
            string[] values = {"Ace","2","3","4","5","6",
                "7","8","9","10","Jack","Queen","King"};
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            int count = 0;

            deck = new PlayingCard[deckSize];
            
            for (int s = 0; s < suits.Length; s++)//loop through each suit
            {
                for (int v=0; v<values.Length;v++)    //loop through each card in each suit
                {
                    deck[count] = new PlayingCard(values[v], suits[s]);
                    count++;
                }
            }
            
            for(int x = 0; x < values.Length; x++)
            {
                if (values[x] =="Jack"|| values[x] == "Queen"|| values[x] == "King" )//if its a face card set points to 10
                {
                    Points = 10;
                }
                else if (values[x] == "Ace") // If it's an ace set points to 11
                {
                    Points = 11;
                }
                else
                {
                    Points = Convert.ToInt32(values[x]);
                }
            }
        }

        public void ShuffleDeck()
        {
            card = 0;   //set current card to zero
            for(int x=0; x<deck.Length; x++)//loop through all cards in deck and shuffle them
            {
                int y = randomNumber.Next(deckSize);
                PlayingCard temp=deck[x];
                deck[x] = deck[y];
                deck[y] = temp;
            }
        }

        public PlayingCard DealCard(Player player)
        {
            if (card < deck.Length)     //check its in bounds of array
            {
                return deck[card++];
            }
            else
            {
                return null;
            }
        }
    }
}
