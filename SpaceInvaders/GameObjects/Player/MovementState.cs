using System;

namespace SpaceInvaders
{
    abstract class MovementState
    {
        public enum Name
        {
            EdgeLeft,
            EdgeRight,
            Ready
        }
        public abstract void MoveLeft(Player pPlayer);
        public abstract void MoveRight(Player pPlayer);
        public abstract void HandleTransition(Player pPlayer);
        public Name name;
    }
}
