using System;

namespace SpaceInvaders
{
    abstract class ShipState
    {
        public abstract void MoveLeft(Player pPlayer);
        public abstract void MoveRight(Player pPlayer);
        public abstract void HandleTransition(Player pPlayer);
    }
}
