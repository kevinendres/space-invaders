using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Squid : EnemyBase
    {
        public Squid(float x, float y)
            : base(Name.Squid, SpriteAdaptor.Name.Squid, x, y) { }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
    }
}
