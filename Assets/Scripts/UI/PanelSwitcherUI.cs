using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelSwitcherUI : MonoBehaviour
{   
    private Boot _boot;
    private UI _ui;
    public List<GameObject> panels;
    public List<Button> buttons;

    public void Init(Boot boot, UI ui) {
        _boot = boot;
        _ui = ui;
        buttons[0].onClick.AddListener(() => { Select(0); });
        buttons[1].onClick.AddListener(() => { Select(1); });
    }

    public void Select(int index) {
        for (int i = 0; i < panels.Count; i++) {
            panels[i].SetActive(i == index);
        }
    }
}