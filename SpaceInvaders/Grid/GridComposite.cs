using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GridComposite : Composite
    {
        public GridComposite(ProxySprite _proxy, float _x, float _y)
            : base(Name.Grid, _proxy, _x, _y) { }
        public override void Clear()
        {
            base.Clear();
        }

        public override bool Compare(NodeBase other)
        {
            return base.Compare(other);
        }

        public override object GetName()
        {
            return name;
        }

        public override void Move(float _x, float _y)
        {
            base.Move(_x, _y);
        }

        public override void Print()
        {
        }

        public override void PushToProxySprite()
        {
        }
        protected void Reset()
        {
            poCollisionObject.poCollisionRectangle.x = 0;
            poCollisionObject.poCollisionRectangle.y = 0;
            poCollisionObject.poCollisionRectangle.width = 0;
            poCollisionObject.poCollisionRectangle.height = 0;
        }
        public void ActivateSpriteBox(SpriteBatch spriteBatch)
        {
            IteratorBase pIt = GetChildrenIterator();
            ColumnComposite tmpCol = (ColumnComposite)pIt.Current();
            while (pIt.IsValid()) {
                spriteBatch.Attach(tmpCol.poCollisionObject.pSpriteBox);
                tmpCol = (ColumnComposite)pIt.Next();
            }
            spriteBatch.Attach(poCollisionObject.pSpriteBox);
        }
        public override void Update()
        {
            CollisionRectangle localRect = poCollisionObject.poCollisionRectangle;
            IteratorBase pIt = GetChildrenIterator();
            ColumnComposite tmpCol = (ColumnComposite)pIt.Current();
            Reset();
            while (pIt.IsValid()) {
                tmpCol.Update();

                //If the Column has no Aliens in it, don't union it's Rectangle
                //It resets the X,Y to 0,0 which will extend the grid's Rectangle to include that
                if (tmpCol.poCollisionObject.poCollisionRectangle.width != 0 && 
                    tmpCol.poCollisionObject.poCollisionRectangle.height != 0) {

                    localRect.Union(tmpCol.poCollisionObject.poCollisionRectangle);
                }
                tmpCol = (ColumnComposite)pIt.Next();
            }
            poCollisionObject.UpdatePosition(poCollisionObject.poCollisionRectangle.x, poCollisionObject.poCollisionRectangle.y);
        }
        public override void Accept(CollisionVisitor other)
        {
            IteratorBase pColumIterator = GetChildrenIterator();
            GameObjectBase pCurrent;
            while (pColumIterator.IsValid()) {
                pCurrent = (GameObjectBase)pColumIterator.Current();
                if (CollisionRectangle.Intersect(pCurrent, (GameObjectBase)other)) {
                    pCurrent.Accept(other);
                    break;
                }
                pColumIterator.Next();
            }
        }
        public override void AttachChildren(Component _child)
        {
            Composite pChild = (Composite)_child;
            pChild.SetCompositeParent(this);
            ++ColumnCount;
            base.AttachChildren(_child);
        }
    }
}
