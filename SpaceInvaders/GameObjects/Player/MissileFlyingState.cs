using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileFlyingState : MissileState
    {
        public override void HandleTransition(Player pPlayer)
        {
            PlayerManager.ChangeMissileState();
        }

        public override void Shoot(Player pPlayer)
        {
            //do nothing
        }
    }
}
