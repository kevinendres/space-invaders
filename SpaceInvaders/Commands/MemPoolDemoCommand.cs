using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MemPoolDemoCommand : CommandBase
    {
        public MemPoolDemoCommand(Texture _pBirdsTexture, Image _pCrab1, Image _pCrab2, float _deltaTime)
        {
            pBirdsTexture = _pBirdsTexture;
            pCrab1 = _pCrab1;
            pCrab2 = _pCrab2;
            deltaTime = _deltaTime;

        }
        public override void Execute(float deltaTime)
        {
            ImageManager.Print();

            ImageManager.Remove(pCrab1);
            ImageManager.Remove(pCrab2);

            ImageManager.Print();

            //Image pImageRedBird = ImageManager.Add(Image.Name.RedBird, pBirdsTexture, 47f, 41f, 48f, 46f);
            //Debug.Assert(pImageRedBird != null);

/*            Image pImageGreenBird = ImageManager.Add(Image.Name.GreenBird, pBirdsTexture, 246f, 135f, 99f, 72f);
            Debug.Assert(pImageGreenBird != null);
*/            ImageManager.Print();
        }

        Texture pBirdsTexture;
        Image pCrab1;
        Image pCrab2;
        float deltaTime;
    }
}
