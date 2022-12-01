using System;

namespace SpaceInvaders
{
    class MoveLeftObserver : InputObserver
    {
        public override void Notify()
        {
            PlayerManager.pPlayer.MoveLeft();
        }
    }
}
