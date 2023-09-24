using System;
using System.Collections.Generic;
using System.Text;

namespace WishingWellModNS
{
    public class DoubleTimeWish : Wish
    {
        public override void UpdateCard()
        {
            WorldManager.instance.AllCards.ForEach(card =>
            {
                if (card.MyBoard == WorldManager.instance.CurrentBoard && card.CardData.Id != Id)
                {
                    card.CardData.UpdateCard();
                }
            });
            base.UpdateCard();
        }
    }
}
