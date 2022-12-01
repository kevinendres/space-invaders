using System;

namespace SpaceInvaders
{
    class RightEdgeState : MovementState
    {
        public RightEdgeState()
        {
            name = Name.EdgeRight;
        }
        public override void HandleTransition(Player pPlayer)
        {
            PlayerManager.ChangeMovementState(Name.Ready);
        }

        public override void MoveLeft(Player pPlayer)
        {
            pPlayer.x -= pPlayer.deltaX;
            HandleTransition(pPlayer);
        }

        public override void MoveRight(Player pPlayer)
        {
            //do nothing
        }
    }
}
