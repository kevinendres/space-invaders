using System;

namespace SpaceInvaders
{
    class MoveRightObserver : InputObserver
    {
        public override void Notify()
        {
            PlayerManager.pPlayer.MoveRight();
        }
    }
}
