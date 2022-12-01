using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ChangeShipStateObserver : CollisionObserver
    {
        public override void Notify()
        {
            if (PlayerManager.pPlayer.x < 100) {
                PlayerManager.ChangeMovementState(MovementState.Name.EdgeLeft);
            } else {
                PlayerManager.ChangeMovementState(MovementState.Name.EdgeRight);
            }
        }
    }
}
