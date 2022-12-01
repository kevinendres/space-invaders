using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Crab : EnemyBase
    {
        public Crab(float x, float y)
            : base(Name.Crab, SpriteAdaptor.Name.Crab, x, y) { }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
    }
}
