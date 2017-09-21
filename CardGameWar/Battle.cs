using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardGameWar
{
    public class Battle
    {
        private List<Card> SpoilsOfWar { get; set; }

        public Battle() => SpoilsOfWar = new List<Card>();

        public string Execute(Card p1Card, Card p2Card, Player player1, Player player2)
        {
            string result = "";

            result += displayBattleCards(p1Card, p2Card);
            result += compareCards(p1Card, p2Card, player1, player2);

            return result;
        }

        public Card GetCard(Player player)
        {
            Card card = player.Hand.First();
            player.Hand.Remove(card);
            SpoilsOfWar.Add(card);
            return card;
        }

        private string displayBattleCards(Card card1, Card card2) =>        
             $"Battle Cards: {card1.Kind} of {card1.Suit}s versus {card2.Kind} of {card2.Suit}s<br/>";        

        private string compareCards(Card p1Card, Card p2Card, Player player1, Player player2)
        {
            string result = "";

            if (p1Card.Value > p2Card.Value)
            { result += displaySpoilsOfWar() + displayRoundWinner(player1); awardSpoilsOfWar(player1); }
            else if (p1Card.Value < p2Card.Value)
            { result += displaySpoilsOfWar() + displayRoundWinner(player2); awardSpoilsOfWar(player2); }
            else if (p1Card.Value == p2Card.Value)
                result += war(player1, player2);

            return result;
        }

        private string displaySpoilsOfWar()
        {
            string result = "Spoils of War...<br/>";
            foreach (var card in SpoilsOfWar)
            {
                result += $"&nbsp&nbsp&nbsp{card.Kind} of {card.Suit}s<br/>";
            }
            return result;
        }       

        private void awardSpoilsOfWar(Player player)
        {
            player.Hand.AddRange(SpoilsOfWar);
            SpoilsOfWar.Clear();
        }

        private string displayRoundWinner(Player player) =>
            $"<strong>{player.Name} has won this round!</strong><br/>";

        private string war(Player player1, Player player2)
        {
            string result = "*****************WAR*****************<br/>";

            GetCard(player1);
            Card p1BattleCard = GetCard(player1);
            GetCard(player2);
            Card p2BattleCard = GetCard(player2);

            result += Execute(p1BattleCard, p2BattleCard, player1, player2);
            return result;
        }

    }
}