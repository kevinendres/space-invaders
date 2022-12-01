using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveGameObjectObserver : CollisionObserver
    {
        public override void Notify()
        {
            pSubject.pColliderA.MarkForDeletion();
            pSubject.pColliderB.MarkForDeletion();
        }
    }
}
