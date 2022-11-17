using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public int drawCounter;

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

        public PlayingCard DealCard(ref Player player)
        {         
            PlayingCard topCard=deck[drawCounter];        //draws top card from deck  
            if (card < deck.Length)     //check its in bounds of array
            {
                player.hand[player.numCardsInHand] = topCard;
                player.numCardsInHand++;
                player.points += topCard.Points;
                drawCounter++;       //draws top card from deck
                return topCard;
            }
            else
            {
                return null;
            }
        }
    }
}
