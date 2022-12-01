using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionPairManager : ManagerBase
    {
        private CollisionPairManager()
            : base(new DLinkList(), new DLinkList(), 10, 41)
        { }
        public static void Initialize()
        {
            Debug.Assert(pManagerInstance == null);
            if (pManagerInstance == null) {
                // LTN - GenericGameObjectManager Singleton
                pManagerInstance = new CollisionPairManager();
            }
        }
        public static CollisionPair Add(CollisionPair.Name _name, GameObjectBase colliderA, GameObjectBase colliderB)
        {
            CollisionPair collisionPair = (CollisionPair)pManagerInstance.AcquireFromBase();
            Debug.Assert(collisionPair != null);
            collisionPair.Set(_name, colliderA, colliderB);
            return collisionPair;
        }
        
        public static void Remove(CollisionPair collisionPair)
        {
            pManagerInstance.ReleaseToBase(collisionPair);
        }
        public NodeBase Find(NodeBase target)
        {
            return baseFind(target);
        }
        protected override NodeBase DerivedCreateNode()
        {
            return new CollisionPair();
        }
        public static CollisionPair GetActiveCollisionPair()
        {
            return pActiveCollisionPair;
        }
        public static void ProcessCollisions()
        {
            IteratorBase pIt = pManagerInstance.poActive.GetIterator();
            CollisionPair pCurrent;
            while (pIt.IsValid()) {
                pCurrent = (CollisionPair)pIt.Current();
                pActiveCollisionPair = pCurrent;
                pCurrent.ProcessCollision();
                pIt.Next();
            }

        }
        public static void Reset()
        {
            pManagerInstance = new CollisionPairManager();
        }
        ~CollisionPairManager()
        {
        }

        private static CollisionPairManager pManagerInstance;
        private static CollisionPair pActiveCollisionPair;
    }
}
