using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    [AddComponentMenu("Slot-Based Save System/UI/Basic/Save Slot Description")]
    public class BasicSaveSlotDescription : SaveSlotText
    {
        [Tooltip("Limit on how many characters from the full description the text field can hold.")]
        [SerializeField] int charLimit = 100;
        [Tooltip("What text to display to suggest that the desc is an abridged version.")]
        [SerializeField] string cutoff = "...";

        public int CharLimit { get { return charLimit; } }

        protected override void UpdateText()
        {
            string toDisplay = DecideWhatToDisplay();
            TextField.text = toDisplay;
        }

        protected virtual string DecideWhatToDisplay()
        {
            if (SaveData.Description.Length > CharLimit)
                return GetTrimmedDesc();
            else
                return SaveData.Description;
        }

        protected virtual string GetTrimmedDesc()
        {
            string baseDesc = SaveData.Description;
            string trimmedDesc = baseDesc.Substring(0, charLimit - cutoff.Length);
            trimmedDesc += cutoff;
            return trimmedDesc;
        }

    }
}