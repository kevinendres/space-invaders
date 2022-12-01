using System;

namespace SpaceInvaders
{
    class MissileFlyingObserver : CollisionObserver
    {
        public override void Notify()
        {
            PlayerManager.ChangeMissileState();
        }
    }
}
