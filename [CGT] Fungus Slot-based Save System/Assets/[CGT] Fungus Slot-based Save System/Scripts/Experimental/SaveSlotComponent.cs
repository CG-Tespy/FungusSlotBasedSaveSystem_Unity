using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public abstract class SaveSlotComponent : MonoBehaviour, ISaveSlotComponent, 
        IGameSaveDataChangedListener
    {
        public virtual GameSaveData saveData { get; set; }

        public virtual void OnSaveDataChanged(GameSaveData oldData, GameSaveData newData) { }

    }
}