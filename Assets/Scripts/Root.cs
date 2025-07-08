namespace Assets.Scripts
{
    using UnityEngine;

    public class Root : MonoBehaviour
    {
        public SceneBootChannel bootChannel;
        public Boot activeBoot;

        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }

        public void OnBootCreated(Boot boot) {
            activeBoot = boot;
            boot.Init(this);
        }
    }
} 