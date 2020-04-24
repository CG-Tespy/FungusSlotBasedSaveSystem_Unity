using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CGTUnity.Fungus.SaveSystem.Experimental
{

    [AddComponentMenu("CGT SB SaveSys/UI/TMPro/Save Slot Description")]
    public class TMProSaveSlotDescription : SaveSlotTMProUGUI
    {

        protected override void UpdateText()
        {
            TextField.text = SaveData.Description;
        }

    }
}