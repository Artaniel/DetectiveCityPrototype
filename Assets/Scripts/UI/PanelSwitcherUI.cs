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
        for (int i = 0; i < buttons.Count; i++) {
            buttons[i].onClick.AddListener(() => {
                Select(i);
            });
        }
    }

    public void Select(int index) {
        for (int i = 0; i < panels.Count; i++) {
            panels[i].SetActive(i == index);
        }
    }
}