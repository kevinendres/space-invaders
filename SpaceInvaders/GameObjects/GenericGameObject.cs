using System;

namespace SpaceInvaders
{
    class GenericGameObject : DLinkNode
    {

        public GenericGameObject()
        {
            pGameObj = null;
        }
        public void Set(GameObjectBase _pGameObj)
        {
            pGameObj = _pGameObj;
            pGameObj.SetParent(this);
        }
        public override void Clear()
        {
            pGameObj = null;
            base.Clear();
        }
        public void Update()
        {
            pGameObj.Update();
        }
        public override void Print()
        {
            // STN -- SHOULD NEVER HAPPEN
            throw new NotImplementedException();
        }
        public void Remove()
        {
            pGameObj.delete = false;
            pGameObj.Remove();
        }
        public bool ToBeRemoved()
        {
            return pGameObj.delete;
        }
        protected GameObjectBase pGameObj;
    }
}
