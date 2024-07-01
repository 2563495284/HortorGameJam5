using System;
namespace Card
{

    public class AttackAction : CardAction
    {
        public AttackAction(float costMp, int lastRound) : base(costMp, lastRound)
        {
        }

        public override void action()
        {
            throw new NotImplementedException();
        }
    }
}

