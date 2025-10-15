using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.NPC;
using UnityEngine.UI;
using Assets.Scripts.NPC.Traits;
using Assets.Scripts.Items;
using TMPro;

public class CharSheetUi : MonoBehaviour
{    
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI activityText;
    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI traitsText;
    public TextMeshProUGUI inventoryText;

    private Npc selectedNpc;
    
    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }
    
    public void SelectNpc(Npc npc) {
        Debug.Log("Selected NPC: " + npc.name);
        UpdateNpcDetails(npc);
    }

    public void UpdateNpcDetails(Npc npc) {
        nameText.text = "Name: " + npc.name;
        locationText.text = "Location: " + npc.state.currentLocation.name;
        activityText.text = "Activity: " + npc.state.currentActivity.ToString();
        hungerText.text = "Hunger: " + npc.state.hunger.ToString("F2");
        energyText.text = "Energy: " + npc.state.energy.ToString("F2");

        string traits = "Traits: ";
        if (npc.data.traitsArray != null && npc.data.traitsArray.Length > 0) {
            foreach (Trait trait in npc.data.traitsArray) {
                traits += trait.name + " (" + npc.data.GetTrait(trait).ToString("F2") + "), ";
            }
            traits = traits.TrimEnd(',', ' ');
        } else {
            traits += "None";
        }
        traitsText.text = traits;

        string inventory = "Inventory: ";
        if (npc.state.inventory != null && npc.state.inventory.Count > 0) {
            foreach (Item item in npc.state.inventory) {
                inventory += item.name + ", ";
            }
            inventory = inventory.TrimEnd(',', ' ');
        } else {
            inventory += "Empty";
        }
        inventoryText.text = inventory;

        npc.state.isLoggingActions = true;
        selectedNpc.state.isLoggingActions = false;
        selectedNpc = npc;
    }
}
