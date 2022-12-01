using System;

namespace SpaceInvaders
{
    class LeftEdgeState : MovementState
    {
        public LeftEdgeState()
        {
            name = Name.EdgeLeft;
        }
        public override void HandleTransition(Player pPlayer)
        {
            PlayerManager.ChangeMovementState(Name.Ready);
        }

        public override void MoveLeft(Player pPlayer)
        {
            //do nothing
        }

        public override void MoveRight(Player pPlayer)
        {
            pPlayer.x += pPlayer.deltaX;
            HandleTransition(pPlayer);
        }
    }
}
