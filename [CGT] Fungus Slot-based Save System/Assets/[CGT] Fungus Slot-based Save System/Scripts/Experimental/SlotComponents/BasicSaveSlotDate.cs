using UnityEngine.UI;
using UnityEngine;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Handles displaying a save slot's date. This is the SBSS's default 
    /// implementation thereof, using Unity's default Text component.
    /// </summary>
    [AddComponentMenu("CGT SB SaveSys/UI/Default/Save Slot Date")]
    public class BasicSaveSlotDate : SaveSlotDate<Text>, ISlotText<Text> { }
}