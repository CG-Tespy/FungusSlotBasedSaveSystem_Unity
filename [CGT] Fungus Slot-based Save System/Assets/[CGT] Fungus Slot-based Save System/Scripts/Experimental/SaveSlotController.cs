using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem
{
    /// <summary>
    /// The main module for UI Save Slots.
    /// </summary>
    public class SaveSlotController : MonoBehaviour, ISaveSlotComponent
    {
        [SerializeField]
        [Tooltip(@"These handle different parts of this slot. If this is empty, the components will
be fetched from this slot's children.")]
        protected List<SaveSlotComponent> components = null;

        public GameSaveData saveData { get; set; } = null;

        protected virtual void Awake()
        {
            if (components == null || components.Count == 0)
                FetchComponentsFromChildren();
        }

        void FetchComponentsFromChildren()
        {
            var componentArr = GetComponentsInChildren<SaveSlotComponent>();
            components = new List<SaveSlotComponent>(componentArr);
        }
    }
}