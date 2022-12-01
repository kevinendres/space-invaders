using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallLeft : WallBase
    {        
        public WallLeft(float x, float y)
            : base(Name.WallLeft, SpriteAdaptor.Name.Wall, x, y) 
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
        public override void Visit(Player player)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(player, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Crab crab)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(crab, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Alien alien)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(alien, this);
            pCurrentPair.Notify();
        }
        public override void Visit(Saucer saucer)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(saucer, NullGameObject.GetInstance());
            pCurrentPair.Notify();
        }
        public override void Visit(Squid squid)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(squid, this);
            pCurrentPair.Notify();
        }
    }
}
