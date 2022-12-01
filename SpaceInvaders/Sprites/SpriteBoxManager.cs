using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxManager : ManagerBase
    {
        private SpriteBoxManager()
            // LTN - SpriteBoxManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 10, 300)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - SpriteBoxManager Singleton
                mManagerInstance = new SpriteBoxManager();
            }
        }
        public static SpriteBoxAdaptor Add(SpriteBoxAdaptor.Name name, float x, float y, float sx, float sy, float R, float G, float B)
        {
            SpriteBoxAdaptor spriteBox = (SpriteBoxAdaptor)mManagerInstance.AcquireFromBase();
            Debug.Assert(spriteBox != null);
            spriteBox.Set(name, x, y, sx, sy, R, G, B);
            return spriteBox;
        }
        public static void Remove(SpriteBoxAdaptor sprite)
        {
            mManagerInstance.ReleaseToBase(sprite);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteBoxAdaptor through ManagerBase
            return new SpriteBoxAdaptor();
        }
        public NodeBase Find(NodeBase target)
        {
            return baseFind(target);
        }
        public static SpriteBoxAdaptor Find(SpriteBoxAdaptor.Name name)
        {
            mManagerInstance.poComparer.name = name;
            return (SpriteBoxAdaptor)mManagerInstance.baseFind(mManagerInstance.poComparer);
        }

        public static void Print()
        {
            Debug.Assert(mManagerInstance != null);
            mManagerInstance.basePrint();
        }
        ~SpriteBoxManager()
        {
        }
        public static void Reset()
        {
            mManagerInstance = new SpriteBoxManager();
        }

        private static SpriteBoxManager mManagerInstance = null;
        private readonly SpriteBoxAdaptor poComparer;
    }
}
