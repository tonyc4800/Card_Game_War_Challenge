using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGameWar
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck(Random random)
        {
            Cards = new List<Card>();
            populateDeck();
            shuffle(random);            
        }

        private void populateDeck()
        {
            generateCards(Suit.Diamond);
            generateCards(Suit.Club);
            generateCards(Suit.Heart);
            generateCards(Suit.Heart);
        }

        private void generateCards(Suit suit)
        {
            // There are 13 cards per suit, which range in value from 2-14. 
            // Face cards start at 11 and above, and essentially
            // in a game of War hold those values.            
            for (int i = 2; i < 15; i++)
            {
                Cards.Add(new Card() { Suit = suit, Kind = (Kind)i, Value = i });
            }
        }

        //Shuffle using Fisher-Yate Shuffle algorithm.
        private void shuffle(Random random)
        {
            int n = Cards.Count;
            while(n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card temp = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = temp;
            }
        }

    }
}