using System;

namespace SpaceInvaders
{
    class WallGroup : WallBase
    {
        public WallGroup(float x, float y)
            : base(Name.WallLeft, SpriteAdaptor.Name.Wall, x, y) 
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            throw new NotImplementedException();
        }
    }
}
