using System;

namespace SpaceInvaders
{
    class AddExplosionObserver : CollisionObserver
    {
        public AddExplosionObserver(SpriteAdaptor.Name _name)
        {
            name = _name;
        }

        public override void Notify()
        {
            TimeEventManager.Add(0.0f, new AddExplosionCommand(name, pSubject.pColliderA.x, pSubject.pColliderA.y));
        }
        SpriteAdaptor.Name name;
    }
}
