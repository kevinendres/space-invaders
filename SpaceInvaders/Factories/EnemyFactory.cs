using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class EnemyFactory : FactoryBase
    {
        public EnemyFactory(SpriteBatch _pSpriteBatch, SpriteBatch _pSpriteBoxBatch)
        {
            Debug.Assert(_pSpriteBatch != null);
            Debug.Assert(_pSpriteBoxBatch != null);

            pSpriteBatch = _pSpriteBatch;
            pSpriteBoxBatch = _pSpriteBoxBatch;
        }

        public override GameObjectBase Create(GameObjectBase.Name name, float x, float y)
        {
            GameObjectBase pGameObj = null;
            switch (name) {
                case GameObjectBase.Name.Alien:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new Alien(x, y);
                    break;
                case GameObjectBase.Name.Crab:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new Crab(x, y);
                    break;
                case GameObjectBase.Name.Squid:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new Squid(x, y);
                    break;
                case GameObjectBase.Name.Saucer:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = Saucer.Initialize(pSpriteBoxBatch);
                    break;
                case GameObjectBase.Name.Player:
                    pGameObj = PlayerManager.InitializePlayer(x, y);
                    break;
                case GameObjectBase.Name.Missile:
                    pGameObj = new Missile(x, y);
                    break;
                case GameObjectBase.Name.WallLeft:
                    pGameObj = new WallLeft(x, y);
                    break;
                case GameObjectBase.Name.WallRight:
                    pGameObj = new WallRight(x, y);
                    break;
                case GameObjectBase.Name.WallTop:
                    pGameObj = new WallTop(x, y);
                    break;
                case GameObjectBase.Name.WallBottom:
                    pGameObj = new WallBottom(x, y);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(pGameObj != null);
            GenericGameObjectManager.Attach(pGameObj);
            pSpriteBatch.Attach(pGameObj.pProxySprite);
            pSpriteBoxBatch.Attach(pGameObj.GetCollisionSprite());
            return pGameObj;
        }

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pSpriteBoxBatch;
    }
}
