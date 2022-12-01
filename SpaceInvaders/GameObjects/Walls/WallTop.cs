using System;

namespace SpaceInvaders
{
    class WallTop : WallBase
    {
        public WallTop(float x, float y)
            : base(Name.WallTop, SpriteAdaptor.Name.FloorCeiling, x, y) { }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
        public override void Visit(Missile missile)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(missile, this);
            pCurrentPair.Notify();
        }
    }
}
