using System;

namespace SpaceInvaders
{
    abstract class MissileState
    {
        public abstract void Shoot(Player pPlayer);
        public abstract void HandleTransition(Player pPlayer);
    }
}
