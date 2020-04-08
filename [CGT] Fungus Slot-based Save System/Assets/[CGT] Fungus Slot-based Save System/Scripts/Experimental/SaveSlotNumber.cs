using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    [AddComponentMenu("Slot-Based Save System/UI/Save Slot Number")]
    public class SaveSlotNumber : SaveSlotComponent
    {
        public Text TextField { get; set; }

        protected virtual void Awake()
        {
            TextField = GetComponent<Text>();
        }
    }
}
