using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextureManager : ManagerBase
    {
        private TextureManager()
            //LTN - TextureManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 5, 5)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - TextureManager
                mManagerInstance = new TextureManager();
            }
        }

        public static Texture Add(Texture.Name _name, string _filename)
        {
            Texture texture = (Texture)mManagerInstance.AcquireFromBase();
            Debug.Assert(texture != null);
            texture.Set(_name, _filename);
            return texture;
        }
        
        public static void Remove(Texture texture)
        {
            mManagerInstance.ReleaseToBase(texture);
        }
        public NodeBase Find(NodeBase target)
        {
            return baseFind(target);
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - TextureManager through ManagerBase
            return new Texture();
        }
        public static void Print()
        {
            Debug.Assert(mManagerInstance != null);
            mManagerInstance.basePrint();
        }
        public static Texture GetTexture()
        {
            return (Texture)mManagerInstance.poActive.GetIterator().Current();
        }

        private static TextureManager mManagerInstance = null;
    }
}
