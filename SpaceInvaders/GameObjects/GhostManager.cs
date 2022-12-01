using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GhostManager : ManagerBase
    {
        private GhostManager()
            // LTN - GhostManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 10, 104)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(mManagerInstance == null);
            if (mManagerInstance == null) {
                // LTN - GhostManager Singleton
                mManagerInstance = new GhostManager();
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
            // LTN - GhostManager through ManagerBase
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
        ~GhostManager()
        {
        }
        public static void Reset()
        {
            mManagerInstance = new GhostManager();
        }

        private static GhostManager mManagerInstance;
    }
}
