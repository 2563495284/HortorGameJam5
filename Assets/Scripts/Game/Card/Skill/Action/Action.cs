using System;
namespace Card
{
    public abstract class CardAction
    {
        public float costMp;

        public int lastRound;

        public abstract void action();

        public CardAction(float costMp, int lastRound)
        {
            this.costMp = costMp;
            this.lastRound = lastRound;
        }
    }
}

