using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGTUnity.Fungus.SaveSystem
{
    public interface ISaveSlotComponent
    {
        /// <summary>
        /// The component does its work based off of this.
        /// </summary>
        GameSaveData saveData { get; }
    }

}