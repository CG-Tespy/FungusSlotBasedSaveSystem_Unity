using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMProUGUI = TMPro.TextMeshProUGUI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{

    [AddComponentMenu("CGT SB SaveSys/UI/TMPro/Save Slot Description")]
    public class TMProSaveSlotDescription : 
        SaveSlotDescription<TMProUGUI>,
        ISlotText<TMProUGUI>
    { }
}