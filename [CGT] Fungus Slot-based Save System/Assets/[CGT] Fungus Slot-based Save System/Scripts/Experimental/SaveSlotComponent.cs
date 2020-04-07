using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem
{
    public abstract class SaveSlotComponent : MonoBehaviour, ISaveSlotComponent
    {
        public GameSaveData saveData { get; set; }
    }
}