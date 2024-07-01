using System;
namespace Card
{

    public class CureAction : CardAction
    {
        public CureAction(float costMp, int lastRound) : base(costMp, lastRound)
        {
        }

        public override void action()
        {
            throw new NotImplementedException();
        }
    }
}

