using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory 
    {
        public ShieldFactory(SpriteBatch _pSpriteBatch, SpriteBatch _pSpriteBoxBatch)
        {
            Debug.Assert(_pSpriteBatch != null);
            Debug.Assert(_pSpriteBoxBatch != null);

            pSpriteBatch = _pSpriteBatch;
            pSpriteBoxBatch = _pSpriteBoxBatch;
        }

        public GameObjectBase Create(SpriteAdaptor.Name name, float x, float y)
        {
            GameObjectBase pGameObj = new ShieldBrick(name, x, y);

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
