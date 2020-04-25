using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMProUGUI = TMPro.TextMeshProUGUI;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Handles displaying a Save Slot's number with a TextMeshPro UGUI component.
    /// </summary>
    [AddComponentMenu("Fungus/CGT SB SaveSys/UI/TMPro/Save Slot Number")]
    public class TMProSaveSlotNumber : 
        SaveSlotNumber<TMProUGUI>,
        ISlotText<TMProUGUI>
    { }
}