using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.NPC;
using Assets.Scripts.Crime;
using Assets.Scripts.NPC.Traits;
using Assets.Scripts.Items;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class CrimeUi : MonoBehaviour
{
    private Boot _boot;
    private DebugToolsUi _debugToolsUi;

    public TextMeshProUGUI timeStampText;
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI stolenItemText;
    public TextMeshProUGUI suspectsText;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI resolutionText;

    public TMPro.TMP_Dropdown suspectsDropdown;
    public Button accuseButton;

    private Crime selectedCrime;

    public void Init(Boot boot, DebugToolsUi debugToolsUi) {
        _boot = boot;
        _debugToolsUi = debugToolsUi;
    }

    public void SelectCrime(Crime crime) {
        RefreshCrimeDetails(crime);
    }

    public void RefreshCrimeDetails(Crime crime) {
        timeStampText.text = "Time: " + crime.timeStamp.ToString("F0") + " minutes";
        locationText.text = "Location: " + crime.location.name;
        stolenItemText.text = "Stolen Item: " + crime.stolenItem.name;

        string suspects = "Suspects: ";
        if (crime.suspects != null && crime.suspects.Count > 0) {
            foreach (Npc suspect in crime.suspects) {
                suspects += suspect.name + ", ";
            }
            suspects = suspects.TrimEnd(',', ' ');
        } else {
            suspects += "None";
        }
        suspectsText.text = suspects;

        statusText.text = "Status: " + crime.status.ToString();
        resolutionText.text = "Resolution: " + crime.resolution.ToString();

        suspectsDropdown.ClearOptions();
        suspectsDropdown.AddOptions(
            crime.suspects.Select(s => new TMP_Dropdown.OptionData(s.name)).ToList()
            );
            
        accuseButton.onClick.AddListener(() => {
            _debugToolsUi.crimeUi.AccuseSelected();
        });
        selectedCrime = crime;
    }

    private void AccuseSelected() {
        if (selectedCrime == null) return;
        Npc accused = selectedCrime.suspects[suspectsDropdown.value];
        if (accused == selectedCrime.criminal) {
            selectedCrime.resolution = CrimeResolution.Caught;
            Debug.Log("Crime resolved: " + selectedCrime.resolution.ToString());
        } else {
            selectedCrime.resolution = CrimeResolution.Mistake;
            Debug.Log("Crime resolved: " + selectedCrime.resolution.ToString());
        }
        selectedCrime.status = CrimeStatus.Closed;
        RefreshCrimeDetails(selectedCrime);
    }
}