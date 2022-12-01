using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GridFactory : FactoryBase
    {
        public GridFactory(SpriteBatch _pSpriteBoxBatch)
        {
            Debug.Assert(_pSpriteBoxBatch != null);

            pSpriteBoxBatch = _pSpriteBoxBatch;
        }

        public override GameObjectBase Create(GameObjectBase.Name name, float x, float y)
        {
            GameObjectBase pGameObj = null;
            switch (name) {
                case GameObjectBase.Name.Grid:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new GridComposite(NullProxySprite.GetInstance(), x, y);
                    Debug.Assert(pGameObj != null);
                    GenericGameObjectManager.Attach(pGameObj);
                    break;
                case GameObjectBase.Name.Column:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new ColumnComposite(NullProxySprite.GetInstance(), x, y);
                    break;
                case GameObjectBase.Name.ShieldColumn:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new ShieldColumn(NullProxySprite.GetInstance(), x, y);
                    break;
                case GameObjectBase.Name.ShieldGrid:
                    // LTN - Attaches to GenericGameObjectManager below
                    pGameObj = new ShieldGrid(NullProxySprite.GetInstance(), x, y);
                    Debug.Assert(pGameObj != null);
                    GenericGameObjectManager.Attach(pGameObj);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            pSpriteBoxBatch.Attach(pGameObj.GetCollisionSprite());
            return pGameObj;
        }

        private SpriteBatch pSpriteBoxBatch;
    }
}
