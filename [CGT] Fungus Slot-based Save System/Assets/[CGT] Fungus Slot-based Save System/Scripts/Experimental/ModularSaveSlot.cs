using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    [AddComponentMenu("Slot-Based Save System/UI/Modular Save Slot")]
    public class ModularSaveSlot : SaveSlotComponent
    {
        [SerializeField] List<SaveSlotComponent> components;
        public GameSaveDataEvent SaveDataChanged { get; private set; } = new GameSaveDataEvent();
        public List<SaveSlotComponent> Components
        {
            get { return components; }
        }

        protected virtual void Awake()
        {
            FetchComponentsAsNeeded();
            HookUpComponentsToSignals();
        }

        void FetchComponentsAsNeeded()
        {
            bool hasAssigned = Components != null && Components.Count > 0;

            if (hasAssigned)
                return;

            var componentArr = GetComponentsInChildren<SaveSlotComponent>();
            components = new List<SaveSlotComponent>(componentArr);

        }

        void HookUpComponentsToSignals()
        {
            for (int i = 0; i < components.Count; i++)
            {
                var currentComponent = components[i];

            }
        }
    }
}