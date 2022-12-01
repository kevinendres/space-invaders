using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GlyphManager
    {
        private GlyphManager()
        {

        }

        public static void Initialize()
        {
            if (pInstance == null) {
                pInstance = new GlyphManager();
                Texture pTexture = TextureManager.GetTexture();
                Debug.Assert(pTexture != null);
                pInstance.glyphs = new Image[] {
                ImageManager.Add(Image.Name.A, pTexture, 3, 36, 5, 7),
                ImageManager.Add(Image.Name.B, pTexture, 11, 36, 5, 7),
                ImageManager.Add(Image.Name.C, pTexture, 19, 36, 5, 7),
                ImageManager.Add(Image.Name.D, pTexture, 27, 36, 5, 7),
                ImageManager.Add(Image.Name.E, pTexture, 35, 36, 5, 7),
                ImageManager.Add(Image.Name.F, pTexture, 43, 36, 5, 7),
                ImageManager.Add(Image.Name.G, pTexture, 51, 36, 5, 7),
                ImageManager.Add(Image.Name.H, pTexture, 59, 36, 5, 7),
                ImageManager.Add(Image.Name.I, pTexture, 67, 36, 5, 7),
                ImageManager.Add(Image.Name.J, pTexture, 75, 36, 5, 7),
                ImageManager.Add(Image.Name.K, pTexture, 83, 36, 5, 7),
                ImageManager.Add(Image.Name.L, pTexture, 91, 36, 5, 7),
                ImageManager.Add(Image.Name.M, pTexture, 99, 36, 5, 7),

                ImageManager.Add(Image.Name.N, pTexture, 3, 46, 5, 7),
                ImageManager.Add(Image.Name.O, pTexture, 11, 46, 5, 7),
                ImageManager.Add(Image.Name.P, pTexture, 19, 46, 5, 7),
                ImageManager.Add(Image.Name.Q, pTexture, 27, 46, 5, 7),
                ImageManager.Add(Image.Name.R, pTexture, 35, 46, 5, 7),
                ImageManager.Add(Image.Name.S, pTexture, 43, 46, 5, 7),
                ImageManager.Add(Image.Name.T, pTexture, 51, 46, 5, 7),
                ImageManager.Add(Image.Name.U, pTexture, 59, 46, 5, 7),
                ImageManager.Add(Image.Name.V, pTexture, 67, 46, 5, 7),
                ImageManager.Add(Image.Name.W, pTexture, 75, 46, 5, 7),
                ImageManager.Add(Image.Name.X, pTexture, 83, 46, 5, 7),
                ImageManager.Add(Image.Name.Y, pTexture, 91, 46, 5, 7),
                ImageManager.Add(Image.Name.Z, pTexture, 99, 46, 5, 7),

                ImageManager.Add(Image.Name.Zero, pTexture, 3, 56, 5, 7),
                ImageManager.Add(Image.Name.One, pTexture, 11, 56, 5, 7),
                ImageManager.Add(Image.Name.Two, pTexture, 19, 56, 5, 7),
                ImageManager.Add(Image.Name.Three, pTexture, 27, 56, 5, 7),
                ImageManager.Add(Image.Name.Four, pTexture, 35, 56, 5, 7),
                ImageManager.Add(Image.Name.Five, pTexture, 43, 56, 5, 7),
                ImageManager.Add(Image.Name.Six, pTexture, 51, 56, 5, 7),
                ImageManager.Add(Image.Name.Seven, pTexture, 59, 56, 5, 7),
                ImageManager.Add(Image.Name.Eight, pTexture, 67, 56, 5, 7),
                ImageManager.Add(Image.Name.Nine, pTexture, 75, 56, 5, 7),

                ImageManager.Add(Image.Name.LessThan, pTexture, 83, 56, 5, 7),
                ImageManager.Add(Image.Name.GreaterThan, pTexture, 91, 56, 5, 7),
                ImageManager.Add(Image.Name.Space, pTexture, 99, 56, 5, 7),
                ImageManager.Add(Image.Name.Equals, pTexture, 107, 56, 5, 7),
                ImageManager.Add(Image.Name.Asterisk, pTexture, 115, 56, 5, 7),
                ImageManager.Add(Image.Name.Question, pTexture, 123, 56, 5, 7),
                ImageManager.Add(Image.Name.Hyphen, pTexture, 131, 56, 5, 7)
                };
            }
        }
        public static Image GetGlyph(int ascii)
        {
            if (ascii >= 48 && ascii <= 57) {
                return pInstance.glyphs[ascii - 22];
            } else if (ascii >= 65 && ascii <= 90) {
                return pInstance.glyphs[ascii - 65];
            } else {
                Image pImage = null;
                switch (ascii) {
                    case 60:  // less than
                        pImage = pInstance.glyphs[36];
                        break;
                    case 62:  // greater than
                        pImage = pInstance.glyphs[37];
                        break;
                    case 32:  // space
                        pImage = pInstance.glyphs[38];
                        break;
                    case 61:  // equals
                        pImage = pInstance.glyphs[39];
                        break;
                    case 42:  // asterisk
                        pImage = pInstance.glyphs[40];
                        break;
                    case 63:  // question
                        pImage = pInstance.glyphs[41];
                        break;
                    case 45:  // hyphen
                        pImage = pInstance.glyphs[42];
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }

                return pImage;
            }
        }
        private static GlyphManager pInstance;
        private Image[] glyphs;
    }
}
