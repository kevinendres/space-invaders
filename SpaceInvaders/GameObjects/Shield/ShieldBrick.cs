using System;

namespace SpaceInvaders
{
    class ShieldBrick : GameObjectBase
    {
        public enum Brick
        {
            Brick,
            BrickTL0,
            BrickTL1,
            BrickBL,
            BrickTR0,
            BrickTR1,
            BrickBR
        }
        public ShieldBrick(SpriteAdaptor.Name name, float x, float y)
            : base(Name.ShieldBrick, name, x, y) { }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }

        public override void Visit(Bomb bomb)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(bomb, this);
            pCurrentPair.Notify();
        }
        public override void Move(float _x, float _y)
        {
            throw new NotImplementedException();
        }
    }
}
