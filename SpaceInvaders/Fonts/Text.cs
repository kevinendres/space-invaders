using System;

namespace SpaceInvaders
{
    class Text : DLinkNode
    {
        public enum Name
        {
            ScoreBar,
            P1Score,
            HighScore,
            Play,
            Title,
            ScoreTable,
            LifeCount,
            CreditCount,
            SaucerScore,
            SquidScore,
            CrabScore,
            AlienScore,
            Test,
            GameOver,
            Uninitialized
        }
        public Text()
        {
            name = Name.Uninitialized;
        }
        public void Set(Name _name, string _message, SpriteAdaptor pSprite, float _x, float _y)
        {
            poFontSprite = new FontSprite(pSprite);
            name = _name;
            string message = _message;
            poFontSprite.Set(_message, _x, _y);
        }
        public override bool Compare(NodeBase other)
        {
            Text pText = (Text)other;
            if (name == pText.name) {
                return true;
            } else {
                return false;
            }
        }
        public void ChangeColor(float r, float g, float b)
        {
            poFontSprite.pSprite.ChangeColor(r, g, b);
        }
        public void UpdateMessage(string _message)
        {
            message = _message;
            poFontSprite.UpdateMessage(message);
        }
        public void Activate(SpriteBatch pBatch)
        {
            pBatch.Attach(poFontSprite);
        }
        public void Deactivate(SpriteBatch pBatch)
        {
            pBatch.Detach(poFontSprite.GetContainer());
        }
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public Name name;
        string message;
        FontSprite poFontSprite;
    }
}
