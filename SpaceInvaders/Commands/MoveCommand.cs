using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MoveCommand : CommandBase
    {
        public MoveCommand(Component _pComponent, float _deltaX)
        {
            pComponent = _pComponent;
            deltaX = _deltaX;
            deltaY = 0f;
            alreadySet = false;
            pAlienMovementSound = new PlaySoundCommand();
            pAlienMovementSound.Attach(SoundManager.Find(SoundAdaptor.Name.AlienMovement1));
            pAlienMovementSound.Attach(SoundManager.Find(SoundAdaptor.Name.AlienMovement1));
            pAlienMovementSound.Attach(SoundManager.Find(SoundAdaptor.Name.AlienMovement4));
            pAlienMovementSound.Attach(SoundManager.Find(SoundAdaptor.Name.AlienMovement3));
            firstSpeedUp = true;
            secondSpeedUp = true;
            thirdSpeedUp = true;
        }
        public override void Execute(float deltaTime)
        {
            pComponent.Move(deltaX, deltaY);
            deltaY = 0f;
            Composite pGrid = (Composite)pComponent;
            if (pGrid.AlienCount < 40 && firstSpeedUp) { 
                deltaTime -= .1f;
                firstSpeedUp = false;
            }
            if (pGrid.AlienCount < 25 && secondSpeedUp) {
                deltaTime -= 0.075f;
                secondSpeedUp = false;
            }
            if (pGrid.AlienCount < 15 && thirdSpeedUp) {
                deltaTime -= 0.05f;
                thirdSpeedUp = false;
            }
            if (pGrid.AlienCount > 0) {
                pAlienMovementSound.Execute(deltaTime);
            }
            TimeEventManager.Add(deltaTime, this);
            alreadySet = false;
        }

        public static void SetDeltas(float _x, float _y)
        {
            if (!alreadySet) {
                deltaX *= _x;
                deltaY = _y;
                alreadySet = true;
            }
        }

        static private Component pComponent;
        static bool alreadySet;
        static float deltaX;
        static float deltaY;
        PlaySoundCommand pAlienMovementSound;
        bool firstSpeedUp;
        bool secondSpeedUp;
        bool thirdSpeedUp;
    }
}
