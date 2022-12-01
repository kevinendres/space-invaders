using System;

namespace SpaceInvaders
{
    abstract class Component : CollisionVisitor
    {
        public abstract void Move(float _x, float _y);
        public virtual void SetParent(Composite _column)
        {
            pParent = _column;
        }
        public virtual Composite GetParent()
        {
            return pParent;
        }
        Composite pParent;
    }
}
