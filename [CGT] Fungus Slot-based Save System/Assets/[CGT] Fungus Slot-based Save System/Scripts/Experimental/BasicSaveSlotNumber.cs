using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Handles displaying a save slot's number.
    /// </summary>
    [AddComponentMenu("Slot-Based Save System/UI/Save Slot Number")]
    public class BasicSaveSlotNumber : SaveSlotComponent
    {
        public override GameSaveData SaveData
        {
            get { return base.SaveData; }
            set
            {
                base.SaveData = value;
                UpdateDisplay();
            }
        }

        public Text TextField { get; protected set; }

        protected virtual void Awake()
        {
            TextField = GetComponent<Text>();
        }

        protected virtual void UpdateDisplay()
        {
            string toDisplay;
            int slotNum = GetSlotNumber();

            toDisplay = slotNum.ToString();
            TextField.text = toDisplay; 
        }

        protected virtual int GetSlotNumber()
        {
            if (SaveData == GameSaveData.Null)
                // Null save datas don't have valid slot numbers
                return transform.GetSiblingIndex();
            else
                return SaveData.SlotNumber;
        }


    }
}
