using System;

namespace SpaceInvaders
{
    class NullGameObject : GameObjectBase
    {
        private NullGameObject()
            : base(Name.Uninitialized, NullProxySprite.GetInstance(), 0f, 0f)
        {

        }
        public override void Accept(CollisionVisitor other)
        {
            
        }
        public static NullGameObject GetInstance()
        {
            return pInstance;
        }

        public override void Move(float _x, float _y)
        {
           
        }
        public override void Update()
        {
        }

        public override void Remove()
        {
        }
        private static NullGameObject pInstance = new NullGameObject();
    }
}
