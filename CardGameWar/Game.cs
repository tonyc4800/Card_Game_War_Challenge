using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGameWar
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Deck Deck { get; set; }
        

        public Game(Random random)
        {
            Player1 = new Player("Rick");
            Player2 = new Player("Morty");
            Deck = new Deck(random);            
        }

        public string ExecuteSimulation()
        {
            string result = "";           

            dealCards();
            result += displayStartingHands() + "<br/>";
            int round = 0;
            while(round != 27)
            {
                Battle battle = new Battle();
                Card p1Card = battle.GetCard(Player1);
                Card p2Card = battle.GetCard(Player2);

                result += battle.Execute(p1Card, p2Card, Player1, Player2) + "<br/>";                

                round++;
            }

            result += displayBothPlayersCardCount();
            Player winningPlayer = determineWinner();
            result += displayGameWinner(winningPlayer); 
            return result;
        }

        private void dealCards()
        {            
            while (Deck.Cards.Count != 0)
            {
                handPlayerCard(Player1);
                handPlayerCard(Player2);
            }           
        }

        private void handPlayerCard(Player player)
        {
            Card card = Deck.Cards.First();
            Deck.Cards.Remove(card);
            player.Hand.Add(card);
        }

        private string displayStartingHands()
        {
            string result = "";
            var bothPlayersHands = Player1.Hand.Zip(Player2.Hand, (p1Card, p2Card) => new { p1Card = p1Card, p2Card = p2Card });
            foreach (var card in bothPlayersHands)
            {
                result += $"{Player1.Name} is dealt {card.p1Card.Kind} of {card.p1Card.Suit}s<br/>";
                result += $"{Player2.Name} is dealt {card.p2Card.Kind} of {card.p2Card.Suit}s<br/>";
            }
            return result;
        }

        private Player determineWinner()
        {
            if (Player1.Hand.Count == Player2.Hand.Count)
                return null;
            else if (Player1.Hand.Count > Player2.Hand.Count)
                return Player1;
            else
                return Player2;
        }

        private string displayGameWinner(Player player)
        {
            if (player == null)
                return $"<strong>The game ended in a tie!</strong><br/>";
            else
                return $"<strong>{player.Name.ToUpper()} WINS!</strong><br/>";
        }

        private string displayBothPlayersCardCount()
        {
            return $"{Player1.Name}'s card count: {Player1.Hand.Count}<br/>" +
                   $"{Player2.Name}'s card count: {Player2.Hand.Count}<br/>";
        }
    }
}