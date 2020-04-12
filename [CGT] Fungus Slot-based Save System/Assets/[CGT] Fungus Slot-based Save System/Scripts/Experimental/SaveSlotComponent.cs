using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public abstract class SaveSlotComponent : MonoBehaviour, ISaveSlotComponent
    {
        public static System.Type saveDataType = typeof(GameSaveData);
        public System.Type SaveDataType 
        { 
            get { return saveDataType; } 
        }
        public virtual GameSaveData SaveData { get; set; }
    }

}