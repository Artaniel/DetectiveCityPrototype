using Assets.Scripts.NPC;
using Assets.Scripts.Worlds;
using Assets.Scripts.NPC.Traits;
using UnityEngine;
using Assets.Scripts.Items;

namespace Assets.Scripts.NPC.NpcAction
{
    public class Steal : MonoBehaviour, INpcAction
    {
        private Boot _boot;
        private AiSystem _ai;
        public Trait greed;
        public Trait criminalTrait;
        
        public void Init(Boot boot, AiSystem ai) {
            _ai = ai;
            _boot = boot;
        }

        public bool CanPerform(Npc npc) {
            return npc.state.currentLocation != npc.data.homeLocation
            && npc.state.currentLocation.inventory.Count > 0;
        }

        public float GetUtility(Npc npc) {
            return npc.data.GetTrait(greed) - npc.data.GetTrait(criminalTrait);
        }

        public void Execute(Npc npc) {
            npc.state.isActionComplete = true;
            npc.state.currentActivity = "Stealing";
            npc.data.SetTrait(criminalTrait, 1.0f);
            Item itemToSteal = npc.state.currentLocation.GetRandomItem();
            npc.state.currentLocation.inventory.Remove(itemToSteal);
            npc.state.inventory.Add(itemToSteal);

            Debug.Log($"[{_boot.world.state.currentTimeInMinutes}] {npc.data.characterName}: Steal an item!");    
        }

        public void TickUpdate(float deltaTime, Npc npc) {
        }

        public bool IsComplete(Npc npc) {
            return true;
        }

        public Location GetRequiredLocation(Npc npc) {
            return null;
        }
    }
}