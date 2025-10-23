using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.NPC;
using Assets.Scripts.UI;

public class PanelSwitcherUI : MonoBehaviour
{   
    private Boot _boot;
    private UI _ui;

    public void Init(Boot boot, UI ui) {
        _boot = boot;
        _ui = ui;
    }

    public void Select(int index) {
    }
}