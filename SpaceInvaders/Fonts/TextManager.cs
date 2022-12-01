using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TextManager : ManagerBase
    {
        private TextManager()
            : base(new DLinkList(), new DLinkList(), 5, 5)
        {
        }

        public static void Initialize()
        {
            if (pInstance == null) {
                pInstance = new TextManager();
                Image pImage = (Image)ImageManager.Find(Image.Name.A);
                Debug.Assert(pImage != null);
                pInstance.pSprite = (SpriteAdaptor)SpriteManager.Add(SpriteAdaptor.Name.Font, pImage, 0f, 0f, 20f, 28f);
                Debug.Assert(pInstance.pSprite != null);
                pInstance.poCompare = new Text();
            }
            pInstance.pBatch = SpriteBatchManager.Add(200f);
        }
        public static NodeBase Add(Text.Name name, string message, float x, float y)
        {
            Text pText = (Text)pInstance.AcquireFromBase();
            pText.Set(name, message, pInstance.pSprite, x, y);
            return pText;
        }
        public static void Activate(Text.Name name)
        {
            pInstance.poCompare.name = name;
            Text pText = (Text)pInstance.baseFind(pInstance.poCompare);
            Debug.Assert(pText != null);
            pText.Activate(pInstance.pBatch);
        }
        public static void Deactivate(Text.Name name)
        {
            pInstance.poCompare.name = name;
            Text pText = (Text)pInstance.baseFind(pInstance.poCompare);
            pText.Deactivate(pInstance.pBatch);
        }
        public static Text GetScoreText()
        {
            pInstance.poCompare.name = Text.Name.P1Score;
            Text pText = (Text)pInstance.baseFind(pInstance.poCompare);
            Debug.Assert(pText != null);
            return pText;
        }
        public static Text GetLifeCountText()
        {
            pInstance.poCompare.name = Text.Name.LifeCount;
            Text pText = (Text)pInstance.baseFind(pInstance.poCompare);
            Debug.Assert(pText != null);
            return pText;
        }
        public static void UpdateHighScore(int newScore)
        {
            pInstance.poCompare.name = Text.Name.HighScore;
            Text pText = (Text)pInstance.baseFind(pInstance.poCompare);
            Debug.Assert(pText != null);
            pText.UpdateMessage(newScore.ToString());
        }

        protected override NodeBase DerivedCreateNode()
        {
            return new Text();
        }
        public static void SetSquidBatch(SpriteBatch pBatch)
        {
            pInstance.pSquidBatch = pBatch;
        }
        public static void ToggleSquids()
        {
            pInstance.pSquidBatch.ToggleDrawing();
        }
        private static TextManager pInstance;
        private Text poCompare;
        public SpriteAdaptor pSprite;
        private SpriteBatch pBatch;
        private SpriteBatch pSquidBatch;
    }
}
