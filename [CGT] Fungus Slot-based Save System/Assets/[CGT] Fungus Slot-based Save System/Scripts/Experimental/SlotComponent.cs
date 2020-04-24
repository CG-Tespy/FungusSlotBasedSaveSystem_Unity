using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Base class for all save slot components. By default, they do their thing
    /// when they are assigned save data.
    /// </summary>
    public abstract class SlotComponent : MonoBehaviour, ISlotComponent
    {
        GameSaveData saveData = GameSaveData.Null;
        public virtual GameSaveData SaveData
        {
            get { return saveData; }
            set
            {
                if (value == null)
                    saveData = GameSaveData.Null;
                else
                    saveData = value;

                Refresh();
            }
        }

        /// <summary>
        /// Where the component does the main part of its job.
        /// </summary>
        public abstract void Refresh();
    }

    /// <summary>
    /// Save Slot Component meant to work with a particular other component type.
    /// </summary>
    public abstract class SaveSlotComponent<TComponent> : SlotComponent where
        TComponent: MonoBehaviour
    {
        public virtual TComponent PartnerComponent { get; protected set; }

    }

}