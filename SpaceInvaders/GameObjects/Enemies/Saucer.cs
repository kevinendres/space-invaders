using System;

namespace SpaceInvaders
{
    class Saucer : EnemyBase
    {
        private Saucer(float x, float y)
            : base(Name.Saucer, SpriteAdaptor.Name.Saucer, x, y) 
        {
            rand = new Random();
            pBomb = BombFactory.Create();
        }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }
        public override void Visit(Missile missile)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(missile, this);
            pCurrentPair.Notify();
        }
        public static Saucer GetInstance()
        {
            return pInstance;
        }
        public static Saucer Initialize(SpriteBatch _pCollisionBatch)
        {
            pInstance = new Saucer(-50f, 900f);
            pInstance.pCollisionBatch = _pCollisionBatch;
            return pInstance;
        }

        public static void Activate()
        {
            if (pInstance.rand.Next() % 2 == 0) {
                pInstance.x = 825f;
                pInstance.movementSpeed = -3f;
            }
            else {
                pInstance.x = 60f;
                pInstance.movementSpeed = 3f;
            }
            GenericGameObjectManager.Attach(pInstance);
            SpriteBatchManager.GetTopBatch().Attach(pInstance.pProxySprite);
            pInstance.pCollisionBatch.Attach(pInstance.poCollisionObject.pSpriteBox);
        }
        public override void Remove()
        {
            //reset collision box so it's not constantly triggering collisions
            pInstance.x = -100;
            pInstance.Update();
            base.Remove();
            SoundManager.StopSaucerSound();
        }
        public override void Update()
        {
            this.x += this.movementSpeed;
            base.Update();
        }
        public static void DropBomb()
        {
            pInstance.pBomb.SelectBombType();
            float dropY = pInstance.poCollisionObject.poCollisionRectangle.y - pInstance.poCollisionObject.poCollisionRectangle.height / 2;
            pInstance.pBomb.Drop(pInstance.poCollisionObject.poCollisionRectangle.x, dropY);
        }
        public static void Reset()
        {
            pInstance.Remove();
        }

        private static Saucer pInstance;
        SpriteBatch pCollisionBatch;
        private Random rand;
        Bomb pBomb;
        private float movementSpeed;
    }
}
