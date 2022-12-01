using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Composite : GameObjectBase
    {
        public Composite(Name _name, ProxySprite _proxy, float _x, float _y) 
            : base (_name, _proxy, _x, _y)
        {
            // LTN - Composite
            children = new DLinkList();
        }
        public override void Move(float _x, float _y)
        {
            x += _x;
            y += _y;

            IteratorBase pIt = children.GetIterator();
            Debug.Assert(pIt != null);

            Component pComponent;
            while (pIt.IsValid()) {
                pComponent = (Component)pIt.Current();
                pComponent.Move(_x, _y);
                pIt.Next();
            }
        }

        public virtual void AttachChildren(Component _child)
        {
            children.Add(_child);
            _child.SetParent(this);
        }
        public virtual void DetachChildren(Component _child)
        {
            children.Remove(_child);
        }

        public IteratorBase GetChildrenIterator()
        {
            return children.GetIterator();
        }
        public override void Print()
        {
            // STN - SHOULD NEVER HAPPEN
            throw new NotImplementedException();
        }
        public void IncrementCount()
        {
            ++AlienCount;
        }
        public void DecrementCount()
        {
            --AlienCount;
        }
        public void SetCompositeParent(Composite pCompPar)
        {
            pCompositeParent = pCompPar;
        }

        public int AlienCount;
        public int ColumnCount;
        public Composite pCompositeParent;
        readonly DLinkList children;
    }
}
