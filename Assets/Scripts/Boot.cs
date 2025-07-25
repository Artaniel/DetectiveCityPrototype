namespace Assets.Scripts
{
    using UnityEngine;
    using Assets.Scripts.Worlds;
    using UnityEngine.SceneManagement;
    using Assets.Scripts.NPC; 

    public class Boot : MonoBehaviour
    {    
        private Root _root;
        public SceneBootChannel bootChannel;

        public UI.UI ui;
        public Camera mainCamera;

        public Library library;
        public World world;
        public AiSystem aiSystem;


        private void Awake() {
            if (bootChannel.root == null) {
                SceneManager.LoadScene("BootStrap");
                return;
            }
            bootChannel.BootCreatedSignal(this); 
            if (!mainCamera) mainCamera = Camera.main; 
            
            world.Init(this);            
            aiSystem.Init(this);            
        }

        public void Init(Root root) {
            _root = root;
        }

        public void FixedUpdate(){
            world.clock.ManualFixedUpdate();
        }

    }
}
