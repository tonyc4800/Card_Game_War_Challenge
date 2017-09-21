using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGameWar
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
    }
}