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

    public TextMeshProUGUI timeStampText;
    public TextMeshProUGUI locationText;
    public TextMeshProUGUI stolenItemText;
    public TextMeshProUGUI suspectsText;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI resolutionText;
    public TMP_InputField notesText;
    public TMP_InputField acusedText;

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
        notesText.text = "Notes: " + (string.IsNullOrEmpty(crime.notes) ? "N/A" : crime.notes);

        selectedCrime = crime;
    }
}