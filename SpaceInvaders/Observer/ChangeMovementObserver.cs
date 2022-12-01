using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ChangeMovementObserver : CollisionObserver
    {
        public override void Notify()
        {
            MoveCommand.SetDeltas(-1f, -20f);
        }
    }
}
