using System;
using System.Diagnostics;
using IrrKlang;

namespace SpaceInvaders
{
    class SoundManager : ManagerBase
    {
        private SoundManager()
            : base(new DLinkList(), new DLinkList(), 5, 5)
        {
            poSoundEngine = new ISoundEngine();
            poComparer = new SoundAdaptor();
        }
        public static void Initialize(bool on)
        {
            if (pInstance == null) {
                pInstance = new SoundManager();
            }
            if (!on) {
                pInstance.poSoundEngine.SoundVolume = 0f;
            }
        }
        public static void PlaySound(SoundAdaptor.Name _name)
        {
            SoundAdaptor pSound = Find(_name);
            Debug.Assert(pSound != null);
            pInstance.poSoundEngine.Play2D(pSound.poSound, false, false, false);

        }
        public static void PlaySound(SoundAdaptor pSound)
        {
            pInstance.poSoundEngine.Play2D(pSound.poSound, false, false, false);

        }
        public static void PlayLoopedMusic()
        {
            SoundAdaptor pMusic = Find(SoundAdaptor.Name.Music);
            pInstance.poSoundEngine.Play2D(pMusic.poSound, true, false, false);
        }
        public static void PlaySaucerSound()
        {
            SoundAdaptor pSound = Find(SoundAdaptor.Name.UFO1);
            pInstance.poSaucer = pInstance.poSoundEngine.Play2D(pSound.poSound, true, false, false);
        }
        public static void StopSaucerSound()
        {
            if (pInstance.poSaucer != null) {
                pInstance.poSaucer.Stop();
            }
        }
        public static void Update()
        {
            pInstance.poSoundEngine.Update();
        }
        public static SoundAdaptor Find(SoundAdaptor.Name name)
        {
            pInstance.poComparer.name = name;
            return (SoundAdaptor)pInstance.baseFind(pInstance.poComparer);
        }

        public static NodeBase Add(SoundAdaptor.Name _name, string _file)
        {
            SoundAdaptor pSound = (SoundAdaptor)pInstance.AcquireFromBase();
            Debug.Assert(pSound != null);
            pSound.Set(_name, pInstance.poSoundEngine.AddSoundSourceFromFile(_file));
            return pSound;
        }
        public static void SetVolume(float vol)
        {
            pInstance.poSoundEngine.SoundVolume = vol;
        }
        protected override NodeBase DerivedCreateNode()
        {
            return new SoundAdaptor();
        }

        private static SoundManager pInstance;
        private ISoundEngine poSoundEngine;
        private SoundAdaptor poComparer;
        private ISound poSaucer;
    }
}
