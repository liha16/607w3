using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            // This rule presumes limit of cards is 5
            bool isUnderLimit = a_dealer.CalcScore() < g_hitLimit;
            bool isSoft17 = a_dealer.CalcScore() == g_hitLimit && a_dealer.HasAce();

            return isUnderLimit || isSoft17;
        }
    }
}
