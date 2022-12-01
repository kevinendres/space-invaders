using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class CollisionVisitor : DLinkNode
    {
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public abstract void Accept(CollisionVisitor other);

        // ----------------------------------
        // WALLS
        // ----------------------------------
        public virtual void Visit(WallBase wall)
        {
            Debug.Assert(false);
        }
        public virtual void Visit(WallLeft wall)
        {
            Debug.Assert(false);
        }
        public virtual void Visit(WallRight wall)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(WallTop wall)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(WallBottom wall)
        { 
            Debug.Assert(false);
        }
        // ----------------------------------
        // Enemies
        // ----------------------------------
        public virtual void Visit(Squid squid)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(Crab crab)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(Alien alien)
        { 
            Debug.Assert(false);
        }
/*        public virtual void Visit(Bomb bomb)
        {
            Debug.Assert(false);
        }
*/        public virtual void Visit(Bomb bomb)
        {
            Debug.Assert(false);
        }
        public virtual void Visit(Saucer saucer)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(GridComposite grid)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(ColumnComposite column)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(ShieldGrid shield)
        {
            Debug.Assert(false);
        }
        public virtual void Visit(ShieldBrick shield)
        {
            Debug.Assert(false);
        }
        // ----------------------------------
        // Player
        // ----------------------------------
        public virtual void Visit(Player player)
        { 
            Debug.Assert(false);
        }
        public virtual void Visit(Missile missile)
        { 
            Debug.Assert(false);
        }
    }
}
