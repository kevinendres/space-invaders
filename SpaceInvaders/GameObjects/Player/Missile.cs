using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Missile : Leaf
    {
        public Missile(float x, float y)
            : base(Name.Missile, SpriteAdaptor.Name.Missile, x, 1400f) { }
        public override void Move(float _x, float _y)
        {
            x += _x;
            y += _y;
        }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
        public override void Visit(Alien alien)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(alien, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Crab crab)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(crab, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Squid squid)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(squid, this);
            pCurrentPair.Notify();
        }
        public override void Visit(ShieldBrick shield)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(shield, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Bomb bomb)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(bomb, this);
            pCurrentPair.Notify();
        }
        public override void Update()
        {
            y += deltaY;
            base.Update();
        }
        public void Activate(float _x, float _y)
        {
            x = _x;
            y = _y + deltaY;
        }

        public override void Remove()
        {
            Deactivate();
            PlayerManager.ChangeMissileState();
        }
        public void Deactivate()
        {
            y = 1200f;
            delete = false;
        }

        float deltaY = 15f;
    }
}
