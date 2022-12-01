using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Alien : EnemyBase
    {
        public Alien(float x, float y)
            : base(Name.Alien, SpriteAdaptor.Name.Alien, x, y) { }

        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
    }
}
