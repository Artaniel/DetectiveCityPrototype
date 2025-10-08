using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using Assets.Scripts.NPC;

public class NpcListUi : MonoBehaviour
{
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;
    public GameObject npcButtonPrefab;
    public Transform npcListContainer;

    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }
    
    public void RefreshNpcList() {
        foreach (Transform child in npcListContainer) {
            Destroy(child.gameObject);
        }

        foreach (Npc npc in _boot.world.state.npcs) {
            GameObject buttonObj = Instantiate(npcButtonPrefab, npcListContainer);
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => {
                _debugToolsUi.charSheetUi.SelectNpc(npc);
            });
        }
    }
}
