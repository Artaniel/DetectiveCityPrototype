namespace Assets.Scripts.NPC
{
    using Assets.Scripts.NPC;
    using Assets.Scripts.Worlds;
    using System.Collections.Generic;
    using Traits;
    using UnityEngine;

    public class NPCData : MonoBehaviour
    {
        private Boot _boot;
        private Npc _npc;

        public string characterName;
        public Location homeLocation;

        public Location workLocation;
        public float workStartTime;
        public float workEndTime;
        
        public Trait[] traitsArray;
        public float[] traitValues;
        public Dictionary<Trait, float> traits;

        public void Init(Boot boot, Npc npc) {
            _boot = boot;
            _npc = npc;
            FormTraitsDictionary();
        }

        private void FormTraitsDictionary(){
            traits = new();
            for (int i = 0; i < traitsArray.Length; i++) {
                if (traitValues.Length >= i)
                    traits.Add(traitsArray[i], traitValues[i]);
                else                    
                    traits.Add(traitsArray[i], 1f);
            }

        }
    }
} 