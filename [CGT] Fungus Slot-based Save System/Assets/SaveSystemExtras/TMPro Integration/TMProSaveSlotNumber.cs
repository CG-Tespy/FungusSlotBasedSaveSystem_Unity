using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Handles displaying a Save Slot's number with a TextMeshPro UGUI component.
    /// </summary>
    [AddComponentMenu("CGT SB SaveSys/UI/TMPro/Save Slot Number")]
    public class TMProSaveSlotNumber : SaveSlotTMProUGUI
    {
        [Tooltip("The text displayed right before the number.")]
        [SerializeField] protected string prefix = "Save #";
        [Tooltip("The text displayed right after the number.")]
        [SerializeField] protected string postfix;

        public virtual string Prefix 
        { 
            get { return prefix; } 
            set { prefix = value; }
        }
        public virtual string Postfix 
        { 
            get { return postfix; } 
            set { postfix = value; }
        }

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