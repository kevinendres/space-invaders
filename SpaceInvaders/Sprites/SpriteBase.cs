using System;

namespace SpaceInvaders
{
    abstract class SpriteBase : DLinkNode
    {
        abstract public void Update();
        abstract public void Render();
        public virtual void SetBackLinks(GenericSpriteManager pManager, GenericSprite pGenSprite)
        {
            pParentSpriteBatch = pManager;
            pGenericSprite = pGenSprite;
        }
        public virtual GenericSpriteManager GetParent()
        {
            return pParentSpriteBatch;
        }
        public virtual GenericSprite GetContainer()
        {
            return pGenericSprite;
        }
        GenericSpriteManager pParentSpriteBatch;
        GenericSprite pGenericSprite;
    }
}
