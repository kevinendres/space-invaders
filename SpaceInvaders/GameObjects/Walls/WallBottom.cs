using System;

namespace SpaceInvaders
{
    class WallBottom : WallBase
    {
        public WallBottom(float x, float y)
            : base(Name.WallBottom, SpriteAdaptor.Name.FloorCeiling, x, y) { }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
        public override void Visit(Bomb bomb)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(bomb, NullGameObject.GetInstance());
            pCurrentPair.Notify();

        }
    }
}
