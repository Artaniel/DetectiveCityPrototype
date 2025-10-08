using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.NPC;

public class CharSheetUi : MonoBehaviour
{    
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;
    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }
    
    public void SelectNpc(Npc npc) {
        Debug.Log("Selected NPC: " + npc.name);
        // Update UI elements to show NPC details
    }
}
