using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.NPC;
using Assets.Scripts.Crime;
using Assets.Scripts.NPC.Traits;
using Assets.Scripts.Items;
using TMPro;

public class CrimeUi : MonoBehaviour
{
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;

    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }

    public void SelectCrime(Crime crime) {
        
    }
}