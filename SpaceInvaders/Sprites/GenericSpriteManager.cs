using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GenericSpriteManager : ManagerBase
    {
        public GenericSpriteManager()
            // LTN - GenericSpriteManager through ManagerBase
            : base(new DLinkList(), new DLinkList(), 5, 50)
        {
        }

        public GenericSprite Attach(SpriteBase pSprite)
        {
            GenericSprite sprite = (GenericSprite)this.AcquireFromBase();
            Debug.Assert(sprite != null);
            sprite.Set(pSprite);
            return sprite;
        }
        public void Detach(GenericSprite pSprite)
        {
            this.ReleaseToBase(pSprite);
        }
        public void Render()
        {
            IteratorBase pIt = poActive.GetIterator();
            Debug.Assert(pIt != null);
            GenericSprite pSprite = (GenericSprite)pIt.Begin();
            while (pIt.IsValid()) {
                Debug.Assert(pSprite != null);
                pSprite.Render();
                pSprite = (GenericSprite)pIt.Next();
            }
        }
        public void Update()
        {
            IteratorBase pIt = poActive.GetIterator();
            Debug.Assert(pIt != null);
            GenericSprite pSprite = (GenericSprite)pIt.Begin();
            while (pIt.IsValid()) {
                Debug.Assert(pSprite != null);
                pSprite.Update();
                pSprite = (GenericSprite)pIt.Next();
            }

        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - GenericSpriteManager through ManagerBase
            GenericSprite sprite = new GenericSprite();
            sprite.SetBackLinks(this, sprite);
            return sprite;
        }
    }
}
