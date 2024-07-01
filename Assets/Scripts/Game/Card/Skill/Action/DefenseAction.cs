using System;
namespace Card
{

    public class DefenseAction : CardAction
    {
        public DefenseAction(float costMp, int lastRound) : base(costMp, lastRound)
        {
        }

        public override void action()
        {
            throw new NotImplementedException();
        }
    }
}

