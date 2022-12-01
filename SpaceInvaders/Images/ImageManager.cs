using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : ManagerBase
    {
        private ImageManager()
            // LTN - ImageManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 1, 1)
        {
            poCompare = new Image();
        }

        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // ImageManager Singleton
                mManagerInstance = new ImageManager();
            }
        }
        public static Image Add(Image.Name name, Texture texture, float x, float y, float w, float h)
        {
            Image image = (Image)mManagerInstance.AcquireFromBase();
            Debug.Assert(image != null);
            image.Set(name, texture, x, y, w, h);
            return image;
        }
        public static void Remove(Image image)
        {
            mManagerInstance.ReleaseToBase(image);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - ImageManager through ManagerBase
            return new Image();
        }
        public NodeBase Find(NodeBase target)
        {
            return baseFind(target);
        }
        public static NodeBase Find(Image.Name _name)
        {
            mManagerInstance.poCompare.name = _name;
            return mManagerInstance.baseFind(mManagerInstance.poCompare);
        }
        public static void Print()
        {
            Debug.Assert(mManagerInstance != null);
            mManagerInstance.basePrint();
        }
        public static void Reset()
        {
            mManagerInstance = new ImageManager();
        }

        private static ImageManager mManagerInstance = null;
        private Image poCompare;
    }
}
