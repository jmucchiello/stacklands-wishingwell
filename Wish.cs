using System;
using System.Collections.Generic;
using System.Text;

namespace WishingWellModNS
{
    public class Wish : CardData
    {
        public int Duration;
        public int Frequency; // 1 = rare, 10 = common

        public virtual void Invoke()
        {
            if (Duration > 0)
            {
                MyGameCard.StartTimer(Duration, WishEnds, null, null);
            }
        }

        public void WishEnds()
        {
            MyGameCard.DestroyCard();
        }

        public static void NewWish()
        {

        }
    }
}
