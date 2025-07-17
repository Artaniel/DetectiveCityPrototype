namespace Assets.Scripts
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Root : MonoBehaviour
    {
        public SceneBootChannel bootChannel;
        public Boot activeBoot;

        private void Awake() {
            DontDestroyOnLoad(gameObject);
            bootChannel.root = this;
            SceneManager.LoadScene("Main");
        }

        public void OnBootCreated(Boot boot) {
            activeBoot = boot;
            boot.Init(this);
        }
    }
} 