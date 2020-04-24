using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using DateTime = System.DateTime;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Handles displaying a save slot's date. This is the SBSS's default 
    /// implementation thereof, using Unity's default Text component.
    /// </summary>
    [AddComponentMenu("CGT SB SaveSys/UI/Default/Save Slot Date")]
    public class SaveSlotDate : SlotText
    {
        CultureInfo localCulture = CultureInfo.CurrentCulture;
        string formatSpecifier = "F";
        DateTime date;

        protected override void UpdateText()
        {
            UpdateDate();
            string toDisplay = DecideWhatToDisplay();
            TextField.text = toDisplay;
        }

        protected virtual void UpdateDate()
        {
            date = SaveData.LastWritten;
        }

        protected virtual string DecideWhatToDisplay()
        {
            bool invalidDate = date.Equals(default(DateTime));

            if (invalidDate)
                return "";
            else
                return date.ToString(formatSpecifier, localCulture);
        }
    }
}