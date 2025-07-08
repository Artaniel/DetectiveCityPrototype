using UnityEngine;

public class Root : MonoBehaviour
{
    public SceneBootChannel bootChannel;
    public Boot activeBoot;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnBootCreated(Boot boot) {
        activeBoot = boot;
        boot.Init(this);
    }
} 