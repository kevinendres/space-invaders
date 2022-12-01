using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneContext
    {
        public enum Scene
        {
            Select,
            Play,
            Over
        }
        public SceneContext()
        {
            // reserve the states
            this.poSceneSelect = new SelectSceneState();
            this.poScenePlay = new PlaySceneState();
            this.poSceneOver = new GameOverSceneState();

            // initialize to the select state
            this.pSceneState = this.poSceneSelect;
            this.pSceneState.Entering();
        }

        public SceneState GetState()
        {
            return this.pSceneState;
        }
        public void SetState(Scene eScene)
        {
            switch (eScene) {
                case Scene.Select:
                    this.pSceneState.Leaving();
                    this.pSceneState = poSceneSelect;
                    this.pSceneState.Entering();
                    break;

                case Scene.Play:
                    this.pSceneState.Leaving();
                    this.pSceneState = poScenePlay;
                    this.pSceneState.Entering();
                    break;

                case Scene.Over:
                    this.pSceneState.Leaving();
                    this.pSceneState = poSceneOver;
                    this.pSceneState.Entering();
                    break;
            }
        }
        public void CycleState()
        {
            switch (pSceneState.name) {
                case Scene.Select:
                    SetState(Scene.Play);
                    break;
                case Scene.Play:
                    SetState(Scene.Over);
                    break;
                case Scene.Over:
                    SetState(Scene.Select);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }


        // ----------------------------------------------------
        // Data: 
        // ----------------------------------------------------
        SceneState pSceneState;
        SelectSceneState poSceneSelect;
        GameOverSceneState poSceneOver;
        PlaySceneState poScenePlay;

    }
}
