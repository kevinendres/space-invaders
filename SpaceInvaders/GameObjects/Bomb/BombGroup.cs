using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombGroup : ColumnComposite
    {
        private BombGroup()
            : base(NullProxySprite.GetInstance(), 0f, 0f) { }

        public static void Attach(Bomb pBomb)
        {
            count++;
            pInstance.AttachChildren(pBomb);
            GenericGameObjectManager.Attach(pBomb);
            pInstance.pSpriteBatch.Attach(pBomb.pProxySprite);
            pInstance.pSpriteBoxBatch.Attach(pBomb.GetCollisionSprite());
        }
        public static void Detach(Bomb pBomb)
        {
            count--;
            pInstance.DetachChildren(pBomb);
        }
        public static void Initialize(SpriteBatch pSpriteBatch, SpriteBatch pSriteBoxBatch)
        {
            if (pInstance == null) {
                pInstance = new BombGroup();
                pInstance.pSpriteBatch = pSpriteBatch;
                pInstance.pSpriteBoxBatch = pSriteBoxBatch;
            }
            GenericGameObjectManager.Attach(pInstance);
            pInstance.pSpriteBoxBatch.Attach(pInstance.GetCollisionSprite());
        }
        public static BombGroup GetInstance()
        {
            return pInstance;
        }
        public override void Visit(ShieldBrick brick)
        {
            IteratorBase pIt = GetChildrenIterator();
            Bomb pBomb;
            while (pIt.IsValid()) {
                pBomb = (Bomb)pIt.Current();
                if (CollisionRectangle.Intersect(pBomb, (GameObjectBase)brick)) {
                    pBomb.Visit(brick);
                    break;
                }
                pIt.Next();
            }
        }

        public override void Accept(CollisionVisitor other)
        {
            IteratorBase pIt = pInstance.GetChildrenIterator();
            Bomb pBomb;
            while (pIt.IsValid()) {
                pBomb = (Bomb)pIt.Current();
                if (CollisionRectangle.Intersect(pBomb, (GameObjectBase)other)) {
                    pBomb.Accept(other);
                    break;
                }
                pIt.Next();
            }
        }
        public override void Remove()
        {
            IteratorBase pIt = pInstance.GetChildrenIterator();
            Bomb pBomb;
            while (pIt.IsValid()) {
                pBomb = (Bomb)pIt.Current();
                //move to the next item before deletion
                pIt.Next();
                if (pBomb.delete == true) {
                    pBomb.delete = false;
                    pBomb.Remove();
                }
            }
            delete = true;
        }
        ~BombGroup()
        {
        }

        private static BombGroup pInstance;
        private static int count;
        SpriteBatch pSpriteBatch;
        SpriteBatch pSpriteBoxBatch;
    }
}
