using UnityEngine;

public class Boot : MonoBehaviour
{    
    private Root _root;
    public SceneBootChannel bootChannel;

    public UI ui;
    public Session session;
    public Camera mainCamera;
    public Health health;
    public Sound sound;
    public Monetization monetization;
    public Saveloading saveloading;

    public Library library;


    private void Awake() {
        bootChannel.BootCreatedSignal(this);
        mainCamera = Camera.main;
        ui.Init(this);
        sound.Init(this);
        monetization.Init(this);
        session.Init(this);
    }

    public void Init(Root root) {
        _root = root;
    }

    private void Start() {
        saveloading.Init(this);
    }
}
