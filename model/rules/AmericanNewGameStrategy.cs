using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            string[] order = {"player", "dealer", "player", "dealer"}; 
            //Card c;
            int i = 1;
            foreach (var player in order)
            {
                if (player == "player")
                {
                    handACard(a_deck, a_player);
                } else if (order.Length == i) // last player 
                {
                    handACard(a_deck, a_dealer, false);
                } 
                i++;
            }

            // c = a_deck.GetCard();
            // c.Show(true);
            // a_player.DealCard(c);

            // c = a_deck.GetCard();
            // c.Show(true);
            // a_dealer.DealCard(c);

            // c = a_deck.GetCard();
            // c.Show(true);
            // a_player.DealCard(c);

            // c = a_deck.GetCard();
            // c.Show(false);
            // a_dealer.DealCard(c);

            return true;
        }
        
        private void handACard(Deck a_deck, Player player, bool show = true) 
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(show);
            player.DealCard(c);
        }
    }
}
