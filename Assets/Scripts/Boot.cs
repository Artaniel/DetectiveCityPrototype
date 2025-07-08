namespace Assets.Scripts
{
    using UnityEngine;
    using Assets.Scripts.Worlds;

    public class Boot : MonoBehaviour
    {    
        private Root _root;
        public SceneBootChannel bootChannel;

        public UI.UI ui;
        public Session session;
        public Camera mainCamera;
        public Health health;
        public Sound sound;
        public Monetization monetization;
        public Saveloading saveloading;

        public Library library;
        public World world;


        private void Awake() {
            bootChannel.BootCreatedSignal(this);
            mainCamera = Camera.main;
            ui.Init(this);
            sound.Init(this);
            monetization.Init(this);
            session.Init(this);
            
            world.Init(this);
        }

        public void Init(Root root) {
            _root = root;
        }

        private void Start() {
            saveloading.Init(this);
        }
    }
}
