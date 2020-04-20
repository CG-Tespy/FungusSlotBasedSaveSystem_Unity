using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Handles displaying a save slot's number.
    /// </summary>
    [AddComponentMenu("Slot-Based Save System/UI/Basic/Save Slot Number")]
    public class BasicSaveSlotNumber : SaveSlotText
    {
        [Tooltip("The text displayed right before the number.")]
        [SerializeField] protected string prefix = "Save #";
        [Tooltip("The text displayed right after the number.")]
        [SerializeField] protected string postfix;

        public string Prefix { get { return prefix; } }
        public string Postfix { get { return postfix; } }

        protected override void UpdateText()
        {
            string toDisplay = prefix + GetSlotNumber() + postfix;
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
