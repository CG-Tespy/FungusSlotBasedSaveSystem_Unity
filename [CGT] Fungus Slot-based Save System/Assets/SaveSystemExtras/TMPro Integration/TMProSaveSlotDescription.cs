using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMProUGUI = TMPro.TextMeshProUGUI;

namespace CGT.Unity.Fungus.SBSaveSys
{

    [AddComponentMenu("CGT SB SaveSys/UI/TMPro/Save Slot Description")]
    public class TMProSaveSlotDescription : 
        SaveSlotDescription<TMProUGUI>,
        ISlotText<TMProUGUI>
    { }
}