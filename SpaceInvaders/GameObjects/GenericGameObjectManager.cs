using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GenericGameObjectManager : ManagerBase
    {
        private GenericGameObjectManager()
            // LTN - GenericGameObjectManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 10, 160)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - GenericGameObjectManager Singleton
                mManagerInstance = new GenericGameObjectManager();
            }
        }

        public static GenericGameObject Attach(GameObjectBase pGameObj)
        {
            GenericGameObject pGenGameObj = (GenericGameObject)mManagerInstance.AcquireFromBase();
            Debug.Assert(pGenGameObj != null);
            pGenGameObj.Set(pGameObj);
            return pGenGameObj;
        }
        public static void Detach(GenericGameObject pGenGameObj)
        {
            mManagerInstance.ReleaseToBase(pGenGameObj);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - GenericGameObjectManager through ManagerBase
            return new GenericGameObject();
        }

        public static void Update()
        {
            IteratorBase pIt = mManagerInstance.poActive.GetIterator();
            GenericGameObject current;
            while (pIt.IsValid()) {
                current = (GenericGameObject)pIt.Current();
                current.Update();
                pIt.Next();
            }

        }
        public static GenericGameObjectManager GetInstance()
        {
            return mManagerInstance;
        }
        public static void Reset()
        {
            mManagerInstance = new GenericGameObjectManager();
        }
        ~GenericGameObjectManager()
        {
        }

        private static GenericGameObjectManager mManagerInstance;
    }
}
