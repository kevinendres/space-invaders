using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ColumnComposite : Composite
    {
        public ColumnComposite(ProxySprite _proxy, float _x, float _y)
            : base(Name.Column, _proxy, _x, _y) 
        {
            BombReady = true;
            rand = new Random();
            pDummyBomb = BombFactory.Create();
            pDummyBomb.SetColumn(this);
        }
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
        public void ActivateSpriteBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Attach(poCollisionObject.pSpriteBox);
        }
        private void Reset()
        {
            poCollisionObject.poCollisionRectangle.x = 0;
            poCollisionObject.poCollisionRectangle.y = 0;
            poCollisionObject.poCollisionRectangle.width = 0;
            poCollisionObject.poCollisionRectangle.height = 0;
        }
        public override void Update()
        {
            CollisionRectangle localRect = poCollisionObject.poCollisionRectangle;
            IteratorBase pIt = GetChildrenIterator();
            GameObjectBase tmpGO = (GameObjectBase)pIt.Current();
            if (tmpGO == null) {
                BombReady = false;
            }
            Reset();
            while (pIt.IsValid()) {
                tmpGO.Update();
                localRect.Union(tmpGO.poCollisionObject.poCollisionRectangle);
                tmpGO = (GameObjectBase)pIt.Next();
            }
            poCollisionObject.UpdatePosition(poCollisionObject.poCollisionRectangle.x, poCollisionObject.poCollisionRectangle.y);
        }

        public override void PushToProxySprite()
        {
        }
        public override void Accept(CollisionVisitor other)
        {
            IteratorBase pIt = GetChildrenIterator();
            GameObjectBase pCurrent;
            while (pIt.IsValid()) {
                pCurrent = (GameObjectBase)pIt.Current();
                if (CollisionRectangle.Intersect(pCurrent, (GameObjectBase)other)) {
                    pCurrent.Accept(other);
                    break;
                }
                pIt.Next();
            }
        }
        public void DropBomb()
        {
            if (BombReady) {
                pDummyBomb.SelectBombType();
                float dropY = poCollisionObject.poCollisionRectangle.y - poCollisionObject.poCollisionRectangle.height / 2;
                pDummyBomb.Drop(poCollisionObject.poCollisionRectangle.x, dropY);
            }
        }
        public override void AttachChildren(Component _child)
        {
            pCompositeParent.IncrementCount();
            ++AlienCount;
            base.AttachChildren(_child);
        }
        public override void DetachChildren(Component _child)
        {
            pCompositeParent.DecrementCount();
            --AlienCount;
            base.DetachChildren(_child);
            if (AlienCount == 0) {
                pCompositeParent.ColumnCount--;
                pCompositeParent.DetachChildren(this);
                Update();
            }
        }
        public bool BombReady;
        Random rand;
        Bomb pDummyBomb;
    }
}
