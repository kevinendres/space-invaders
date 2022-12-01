using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AddExplosionCommand : CommandBase
    {
        public AddExplosionCommand(SpriteAdaptor.Name _name, float _x, float _y)
        {
            name = _name;
            x = _x;
            y = _y;
            if (name == SpriteAdaptor.Name.SaucerExplosion) {
                y += 10;
            }
        }
        public override void Execute(float deltaTime)
        {
            SpriteBatch pBatch = SpriteBatchManager.GetTopBatch();
            SpriteAdaptor pExplosion = SpriteManager.Find(name);
            ProxySprite pProxy = ProxySpriteManager.Add(ProxySprite.Name.Proxy, x, y, pExplosion);
            GenericSprite pSprite = pBatch.Attach(pProxy);
            TimeEventManager.Add(0.25f, new RemoveExplosionCommand(pSprite));
        }
        SpriteAdaptor.Name name;
        float x;
        float y;
    }
}
