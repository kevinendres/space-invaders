using System;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        public override void Notify()
        {
            PlayerManager.pPlayer.Shoot();
        }

    }
}
