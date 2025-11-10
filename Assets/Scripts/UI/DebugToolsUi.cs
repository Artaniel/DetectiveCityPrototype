using Assets.Scripts.UI;
using UnityEngine;
using Assets.Scripts;

public class DebugToolsUi : MonoBehaviour
{
    private Boot _boot;
    private UI _ui;
    public NpcListUi npcListUi;
    public CharSheetUi charSheetUi;
    public CrimeListUi crimeListUi;
    public CrimeUi crimeUi;
        
    public void Init(Boot boot, UI ui)
    {
        _boot = boot;
        _ui = ui;
        npcListUi.Init(boot, this);
        charSheetUi.Init(boot, this);
        crimeListUi.Init(boot, this);
        crimeUi.Init(boot, this);
    }
    
    public void TickUpdate(float deltatime) {
        npcListUi.TickUpdate(deltatime);
        crimeListUi.TickUpdate(deltatime);
    }
}
