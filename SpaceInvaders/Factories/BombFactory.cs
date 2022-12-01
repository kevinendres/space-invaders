using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombFactory
    {
        private BombFactory(SpriteBatch _pSpriteBatch, SpriteBatch _pSpriteBoxBatch)
        {
            Debug.Assert(_pSpriteBatch != null);
            Debug.Assert(_pSpriteBoxBatch != null);

            pSpriteBatch = _pSpriteBatch;
            pSpriteBoxBatch = _pSpriteBoxBatch;
        }
        public static void Initalize(SpriteBatch _pSpriteBatch, SpriteBatch _pSpriteBoxBatch, WallBottom pFloor)
        {
            if (pInstance == null) {
                pInstance = new BombFactory(_pSpriteBatch, _pSpriteBoxBatch);
                pInstance.pFloor = pFloor;
            }

        }
        public static Bomb Create()
        {
            Bomb pDummyBomb = new Bomb();

            GenericGameObjectManager.Attach(pDummyBomb);
            pInstance.pSpriteBatch.Attach(pDummyBomb.pProxySprite);
            pInstance.pSpriteBoxBatch.Attach(pDummyBomb.GetCollisionSprite());

            // --- dummy bomb vs player
            CollisionPair pDummyBomb_Player = CollisionPairManager.Add(CollisionPair.Name.Bomb_Player, pDummyBomb, PlayerManager.GetPlayer());
            pDummyBomb_Player.poSubject.Attach(new RemoveGameObjectObserver());
            pDummyBomb_Player.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.PlayerExplosion));
            pDummyBomb_Player.poSubject.Attach(new PlaySoundObserver(SoundAdaptor.Name.PlayerDeath));
            pDummyBomb_Player.poSubject.Attach(new PlayerLifeCountObserver());

            CollisionPair pDummyBomb_Missile = CollisionPairManager.Add(CollisionPair.Name.Bomb_Missile, pDummyBomb, PlayerManager.GetMissile());
            pDummyBomb_Missile.poSubject.Attach(new RemoveGameObjectObserver());
            pDummyBomb_Missile.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.AlienExplosion));

            CollisionPair pDummyDomb_Shield1 = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, pDummyBomb, ShieldManager.GetShield(1));
            pDummyDomb_Shield1.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pDummyDomb_Shield2 = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, pDummyBomb, ShieldManager.GetShield(2));
            pDummyDomb_Shield2.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pDummyDomb_Shield3 = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, pDummyBomb, ShieldManager.GetShield(3));
            pDummyDomb_Shield3.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pDummyDomb_Shield4 = CollisionPairManager.Add(CollisionPair.Name.Bomb_Shield, pDummyBomb, ShieldManager.GetShield(4));
            pDummyDomb_Shield4.poSubject.Attach(new RemoveGameObjectObserver());

            CollisionPair pDummyBomb_Floor = CollisionPairManager.Add(CollisionPair.Name.Bomb_Floor, pDummyBomb, pInstance.pFloor);
            pDummyBomb_Floor.poSubject.Attach(new RemoveGameObjectObserver());
            pDummyBomb_Floor.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.AlienShotExplosion));

            return pDummyBomb;
        }
        public static void Reset()
        {
            pInstance = null;
        }
        static BombFactory pInstance;
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pSpriteBoxBatch;
        private WallBottom pFloor;
    }
}
