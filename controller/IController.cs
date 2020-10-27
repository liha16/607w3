using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    interface IController
    {
        void m_dealer_HandCardCompleted(object sender, EventArgs e);
        
        void StartGame(model.Game a_game, view.IView a_view);

        bool Play();
    }
}
