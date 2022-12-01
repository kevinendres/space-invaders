using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FontSprite : ProxySprite
    {
        public FontSprite(SpriteAdaptor pSpriteAdaptor)
        {
            pSprite = pSpriteAdaptor;
        }
        public void Set(string _message, float _x, float _y)
        {
            message = _message;
            x = _x;
            y = _y;
        }
        public void UpdateMessage(string _message)
        {
            message = _message;
        }
        public override void Render()
        {
            float CHARACTERSIZE = 30f;
            float originalX = x;
            for (int i = 0; i < message.Length; ++i) {
                int ascii = Convert.ToByte(message[i]);
                Image glyph = GlyphManager.GetGlyph(ascii);
                Debug.Assert(glyph != null);
                pSprite.SwapImage(glyph);
                base.Render();
                x += CHARACTERSIZE;
            }
            x = originalX;
        }

        string message;
    }
}
