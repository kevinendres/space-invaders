using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ProxySpriteManager : ManagerBase
    {
        private ProxySpriteManager()
            // LTN - ProxySpriteManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 10, 301)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - ProxySpriteManager Singleton
                mManagerInstance = new ProxySpriteManager();
            }
        }
        public static ProxySprite Add(ProxySprite.Name name, float x, float y, SpriteAdaptor pSprite)
        {
            ProxySprite sprite = (ProxySprite)mManagerInstance.AcquireFromBase();
            Debug.Assert(sprite != null);
            sprite.Set(name, x, y, pSprite);
            return sprite;
        }
        public static void Remove(ProxySprite sprite)
        {
            mManagerInstance.ReleaseToBase(sprite);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - ProxySpriteManager through ManagerBase
            return new ProxySprite();
        }

        public static void Print()
        {
            Debug.Assert(mManagerInstance != null);
            mManagerInstance.basePrint();
        }
        ~ProxySpriteManager()
        {
        }
        public static void Reset()
        {
            mManagerInstance = new ProxySpriteManager();
        }

        private static ProxySpriteManager mManagerInstance = null;
    }
}
