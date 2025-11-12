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
    public Button inspectInventoryButton;
    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI utilityLogText;
    private Npc selectedNpc;
    
    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
        inspectInventoryButton.onClick.AddListener(ShowInventory);
    }
    
    public void SelectNpc(Npc npc) {
        RefreshNpcDetails(npc);
    }

    public void RefreshNpcDetails(Npc npc) {
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

        string utilityLog = "Utility Log:\n";
        if (npc.state.utilityLog != null && npc.state.utilityLog.Count > 0) {
            foreach (var entry in npc.state.utilityLog) {
                utilityLog += entry.Key + ": " + entry.Value.ToString("F2") + "\n";
            }
        } else {
            utilityLog += "Empty";
        }
        utilityLogText.text = utilityLog;

        npc.state.isLoggingActions = true;
        if (selectedNpc) selectedNpc.state.isLoggingActions = false;

        inventoryText.text = "";
        selectedNpc = npc;
    }

    private void ShowInventory() { ShowInventory(selectedNpc); }
    private void ShowInventory(Npc npc) {
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
    }
}
