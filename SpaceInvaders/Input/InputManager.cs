using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputManager
    {
        private InputManager()
        {
            this.poSubjectArrowLeft = new InputSubject();
            this.poSubjectArrowRight = new InputSubject();
            this.poSubjectSpace = new InputSubject();
        }

        public static void Initialize()
        {
            pInstance = new InputManager();
            pInstance.poSubjectArrowLeft.Attach(new MoveLeftObserver());
            pInstance.poSubjectArrowRight.Attach(new MoveRightObserver());
            pInstance.poSubjectSpace.Attach(new ShootObserver());
        }

        public static InputSubject GetArrowRightSubject()
        {
            return pInstance.poSubjectArrowRight;
        }

        public static InputSubject GetArrowLeftSubject()
        {
            return pInstance.poSubjectArrowLeft;
        }

        public static InputSubject GetSpaceSubject()
        {
            return pInstance.poSubjectSpace;
        }

        public static void Update()
        {
            InputManager pMan = pInstance;


            // LeftKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true) {
                pMan.poSubjectArrowLeft.Notify();
            }

            // RightKey: (no history) -----------------------------------------------------------
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true) {
                pMan.poSubjectArrowRight.Notify();
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE)) {
                pMan.poSubjectSpace.Notify();
            }

            // one key switch states
            bool oneKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1);
            if (oneKeyCurr == true && pInstance.oneKeyPrev == false) {
                SpaceInvaders.poSceneContext.CycleState();
            }

            // two key toggle on/off boxes
            bool twoKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2);
            if (twoKeyCurr == true && pInstance.twoKeyPrev == false) {
                SpriteBatchManager.TurnOffBoxes();
            }
            pInstance.oneKeyPrev = oneKeyCurr;
            pInstance.twoKeyPrev = twoKeyCurr;
        }

        // Data: ----------------------------------------------
        private static InputManager pInstance;
        private bool oneKeyPrev;
        private bool twoKeyPrev;

        private InputSubject poSubjectArrowRight;
        private InputSubject poSubjectArrowLeft;
        private InputSubject poSubjectSpace;

    }
}
