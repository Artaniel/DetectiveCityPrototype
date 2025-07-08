using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Channels/SceneBootChannel", fileName = "SceneBootChannel")]
public class SceneBootChannel : ScriptableObject
{
    public Root root;

    public void BootCreatedSignal(Boot boot) {
        root.OnBootCreated(boot);
    }
} 