using System;

namespace SpaceInvaders
{
    class DeletionManager
    {
        private DeletionManager()
        {
        }
        public static void Initialize()
        {
            if (pInstance == null) {
                pInstance = new DeletionManager();
                pInstance.pGameObjManager = GenericGameObjectManager.GetInstance();
            }
        }
        public static void Update()
        {
            IteratorBase pIt = pInstance.pGameObjManager.poActive.GetIterator();
            GenericGameObject pPrevious = (GenericGameObject)pIt.Current();
            pIt.Next();
            while (pIt.IsValid()) {
                if(pPrevious.ToBeRemoved()) {
                    pPrevious.Remove();
                }
                pPrevious = (GenericGameObject)pIt.Current();
                pIt.Next();
            }
            //delete last object if necessary
            if(pPrevious.ToBeRemoved()) {
                pPrevious.Remove();
            }
        }
        public static void Reset()
        {
            pInstance = new DeletionManager();
            pInstance.pGameObjManager = GenericGameObjectManager.GetInstance();
        }
        private static DeletionManager pInstance;
        private GenericGameObjectManager pGameObjManager;
    }
}
