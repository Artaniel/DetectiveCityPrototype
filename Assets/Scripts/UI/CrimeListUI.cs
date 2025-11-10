using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.NPC;
using Assets.Scripts.Crime;

public class CrimeListUi : MonoBehaviour
{
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;
    public ButtonWithTextUI npcButtonPrefab;
    public Transform crimeListContainer;

    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }
    
    public void RefreshCrimeList() {
        foreach (Transform child in crimeListContainer) {
            Destroy(child.gameObject);
        }

        foreach (Crime crime in _boot.world.state.crimes) {
            ButtonWithTextUI buttonAdapter = Instantiate(npcButtonPrefab, crimeListContainer);
            buttonAdapter.button.onClick.AddListener(() => {
                _debugToolsUi.crimeUi.SelectCrime(crime);
            });
            buttonAdapter.buttonText.text = crime.name;
        }
    }
            
    public void TickUpdate(float deltatime) { 
       RefreshCrimeList();
    }
}
