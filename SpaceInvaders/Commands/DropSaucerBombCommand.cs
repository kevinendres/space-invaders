using System;

namespace SpaceInvaders
{
    class DropSaucerBombCommand : CommandBase
    {
        public DropSaucerBombCommand()
        {
        }
        public override void Execute(float deltaTime)
        {
            Saucer.DropBomb();
            TimeEventManager.Add(deltaTime, this);
        }
    }
}
