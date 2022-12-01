using System;

namespace SpaceInvaders
{
    class PlayerLifeCountObserver : CollisionObserver
    {
        public override void Notify()
        {
            Player pPlayer = (Player)pSubject.pColliderA;
            pPlayer.LoseOneLife();
        }
    }
}
