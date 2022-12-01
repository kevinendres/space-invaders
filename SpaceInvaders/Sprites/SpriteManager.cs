using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteManager : ManagerBase
    {
        private SpriteManager()
            // LTN - SpriteManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 5, 5)
        {
            // LTN - SpriteManager
            poComparer = new SpriteAdaptor();
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - SpriteManager Singleton
                mManagerInstance = new SpriteManager();
            }
        }
        public static SpriteAdaptor Add(SpriteAdaptor.Name name, Image image, float x, float y, float w, float h)
        {
            SpriteAdaptor sprite = (SpriteAdaptor)mManagerInstance.AcquireFromBase();
            Debug.Assert(sprite != null);
            sprite.Set(name, image, x, y, w, h);
            return sprite;
        }
        public static SpriteAdaptor Add(SpriteAdaptor.Name name, Image.Name image_name, float x, float y, float w, float h)
        {
            Image image = (Image)ImageManager.Find(image_name);
            SpriteAdaptor sprite = (SpriteAdaptor)mManagerInstance.AcquireFromBase();
            Debug.Assert(sprite != null);
            sprite.Set(name, image, x, y, w, h);
            return sprite;
        }
        public static void Remove(SpriteAdaptor sprite)
        {
            mManagerInstance.ReleaseToBase(sprite);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteManager through ManagerBase
            return new SpriteAdaptor();
        }

        public static SpriteAdaptor Find(NodeBase target)
        {
            return (SpriteAdaptor)mManagerInstance.baseFind(target);
        }
        public static SpriteAdaptor Find(SpriteAdaptor.Name name)
        {
            mManagerInstance.poComparer.name = name;
            return (SpriteAdaptor)mManagerInstance.baseFind(mManagerInstance.poComparer);
        }
        public static void Print()
        {
            Debug.Assert(mManagerInstance != null);
            mManagerInstance.basePrint();
        }
        public static void Reset()
        {
            mManagerInstance = new SpriteManager();
        }

        private static SpriteManager mManagerInstance = null;
        private readonly SpriteAdaptor poComparer;
    }
}
