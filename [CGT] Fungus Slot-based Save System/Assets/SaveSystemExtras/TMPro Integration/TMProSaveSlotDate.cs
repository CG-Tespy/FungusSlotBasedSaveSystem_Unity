using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CGTUnity.Fungus.SaveSystem;
using TMProUGUI = TMPro.TextMeshProUGUI;

namespace CGT.Unity.Fungus.SBSaveSys
{
    public class TMProSaveSlotDate : SaveSlotDate<TMProUGUI>, ISlotText<TMProUGUI>
    { }
}