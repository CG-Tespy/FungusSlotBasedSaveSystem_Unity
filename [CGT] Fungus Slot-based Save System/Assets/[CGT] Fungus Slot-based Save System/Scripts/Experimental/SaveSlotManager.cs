using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Fungus;
using CGTUnity.Fungus.SaveSystem;

namespace CGT.Unity.Fungus.SBSaveSys
{

    /// <summary>
    /// Superclass for the modules managing the slots in the UI.
    /// </summary>
    public abstract class SaveSlotManager
    {
        protected IList<ISlotController> Slots { get; set; }
        public abstract void ClearSlot(int slotNumber);

        public abstract void SetSlotWith(int slotNumber, GameSaveData saveData);
        
    }
}
