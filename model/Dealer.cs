using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;

        private rules.IWhoWinsStrategy m_whoWinsRule;

        public event EventHandler HandCardCompleted;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_whoWinsRule = a_rulesFactory.GetWhoWinsRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                // return m_newGameRule.NewGame(m_deck, this, a_player);   
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                // Card c;
                // c = m_deck.GetCard();
                // c.Show(true);
                // a_player.DealCard(c);
                HandCard(a_player, true);

                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                
                while (m_hitRule.DoHit(this))
                {
                    // Card c;
                    // c = m_deck.GetCard();
                    // c.Show(true);
                    // this.DealCard(c);
                    HandCard(this, true);

                }
                return true;
            }
            return false;
        }


        public bool IsDealerWinner(Player a_player)
        {
            return m_whoWinsRule.isDealerWinner(this, a_player, g_maxScore);   
        }
        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool HandCard(Player a_player, bool show)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);
            OnHandCardCompleted(EventArgs.Empty); //FIRE EVENT 
            return true;
        }

        protected virtual void OnHandCardCompleted(EventArgs e)
        {
            HandCardCompleted?.Invoke(this, e);
        }


    }
}
