using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GenericSprite : SpriteBase
    {

        public GenericSprite()
        {
            pSprite = null;
        }
        public void Set(SpriteBase _pSprite)
        {
            pSprite = _pSprite;
        }
        public override void Clear()
        {
            pSprite = null;
            base.Clear();
        }

        public override void Print()
        {
            pSprite.Print();
        }

        public override void Render()
        {
            pSprite.Render();
        }

        public override void Update()
        {
            pSprite.Update();
        }
        private SpriteBase pSprite;
        ~GenericSprite()
        {
        }
    }
}
