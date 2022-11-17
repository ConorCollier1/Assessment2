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

        public Deck()
        {
            //create card arrays
            string[] values = {"Ace","Two","Three","Four","Five","Six",
                "Seven","Eight","Nine","Ten","Jack","Queen","King"};
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };

            deck = new PlayingCard[deckSize];
            for (int i = 0; i < deck.Length; i++)//loop adding each card to deck one by one
            {
                deck[i] = new PlayingCard(values[i % 11], suits[i / 13]);
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

        public PlayingCard DealCard()
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
