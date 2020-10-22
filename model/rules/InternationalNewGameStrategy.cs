using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
          //  Card c;

            string[] order = {"player", "dealer", "player"}; 

            foreach (var player in order)
            {
                
                if (player == "player")
                {
                    handACard(a_deck, a_player);
                } else
                {
                    handACard(a_deck, a_dealer);
                }
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

            return true;
        }
        
        private void handACard(Deck a_deck, Player player) 
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(true);
            player.DealCard(c);

        }
    }
}
