using UnityEngine;
using Assets.Scripts;

public class CharSheetUi : MonoBehaviour
{    
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;
    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }
}
