using System;

namespace SpaceInvaders
{
    class ShieldColumn : Composite
    {
        public ShieldColumn(ProxySprite _proxy, float _x, float _y)
            : base(Name.Column, _proxy, _x, _y) 
        {
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
        public override void Visit(Bomb bomb)
        {
            IteratorBase pIt = GetChildrenIterator();
            GameObjectBase pCurrent;
            while (pIt.IsValid()) {
                pCurrent = (GameObjectBase)pIt.Current();
                if (CollisionRectangle.Intersect(pCurrent, (GameObjectBase)bomb)) {
                    pCurrent.Visit(bomb);
                    break;
                }
                pIt.Next();
            }
        }
        public GridComposite pGridParent;
    }
}
