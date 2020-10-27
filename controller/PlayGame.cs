using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller 
{
    class PlayGame : IController
    {
        private view.IView view;
        private model.Game game;

        public void StartGame(model.Game a_game, view.IView a_view) {
            game = a_game;
            view = a_view;
            view.DisplayWelcomeMessage();
            subscribeToHandCard();
        }

        private void subscribeToHandCard() {
            model.Dealer m_dealer = game.getDealer();
            m_dealer.HandCardCompleted += m_dealer_HandCardCompleted; 
        }

        public void m_dealer_HandCardCompleted(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            view.DisplayWelcomeMessage();
            view.DisplayDealerHand(game.GetDealerHand(), game.GetDealerScore());
            view.DisplayPlayerHand(game.GetPlayerHand(), game.GetPlayerScore());
        }

        public bool Play()
        {
            if (game.IsGameOver())
            {
                view.DisplayGameOver(game.IsDealerWinner());
            }

            view.SetInputOption();

            if (view.doesUserWantToPlay())
            {
                game.NewGame();
            }
            else if (view.doesUserWantToHit())
            {
                game.Hit();
            }
            else if (view.doesUserWantToStand())
            {
                game.Stand();
            }
            else if(view.doesUserWantToQuit())
            {
                return false;
            }
            return true;

        }
    }
}
