using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGameWar
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Kind Kind { get; set; }
        public int Value { get; set; }                
    }

    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum Kind
    {
        Two = 2,
        Three ,
        Four ,
        Five ,
        Six ,
        Seven ,
        Eight ,
        Nine ,
        Ten ,
        Jack ,
        Queen ,
        King ,
        Ace 
    }
}

