using System;

namespace SpaceInvaders
{
    class MovementReadyState : MovementState
    {
        public MovementReadyState()
        {
            name = Name.Ready;
        }
        public override void HandleTransition(Player pPlayer)
        {
            //do nothing, manager by Observer
        }

        public override void MoveLeft(Player pPlayer)
        {
            pPlayer.x -= pPlayer.deltaX;
        }

        public override void MoveRight(Player pPlayer)
        {
            pPlayer.x += pPlayer.deltaX;
        }
    }
}
