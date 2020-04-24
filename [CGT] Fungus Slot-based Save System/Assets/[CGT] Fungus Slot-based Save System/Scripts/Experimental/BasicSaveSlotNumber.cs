using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Handles displaying a save slot's number.
    /// </summary>
    [AddComponentMenu("Fungus/CGT SB SaveSys/UI/Basic/Save Slot Number")]
    public class BasicSaveSlotNumber : SaveSlotNumber<Text>, ISlotText<Text> { }
}
