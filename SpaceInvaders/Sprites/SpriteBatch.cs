using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatch : OrderedDLinkNode
    {
        public SpriteBatch()
        {
            // LTN - SpriteBatch
            poManager = new GenericSpriteManager();
            drawable = true;
            isSpriteBoxBatch = false;
        }

        public GenericSprite Attach(SpriteBase pSprite)
        {
            GenericSprite pGenSprite = poManager.Attach(pSprite);
            pSprite.SetBackLinks(poManager, pGenSprite);
            return pGenSprite;
        }
        public void Detach(GenericSprite pSprite)
        {
            poManager.Detach(pSprite);
        }
        public void Set(float _key)
        {
            key = _key;
        }
        public void Update()
        {
            poManager.Update();
        }

        public void Render()
        {
            if (drawable) {
                poManager.Render();
            }
        }

        public override void Print()
        {
            // STN - SHOULD NEVER HAPPEN
            throw new NotImplementedException();
        }
        public void ToggleDrawing()
        {
            drawable = !drawable;
        }


        private GenericSpriteManager poManager;
        public float key;
        private bool drawable;
        public bool isSpriteBoxBatch;

    }
}
