using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public abstract class SlotComponent : MonoBehaviour, ISlotComponent
    {
        public static System.Type saveDataType = typeof(GameSaveData);
        public System.Type SaveDataType 
        { 
            get { return saveDataType; } 
        }
        public virtual GameSaveData SaveData { get; set; }
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