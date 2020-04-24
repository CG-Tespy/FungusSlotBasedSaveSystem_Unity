using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public interface ISlotComponent
    {
        System.Type SaveDataType { get; }
        GameSaveData SaveData { get; set; }
    }

    /// <summary>
    /// Generic interface for UI save slot components. TSaveData is the type of GameSaveData
    /// an implementation is meant to work with.
    /// </summary>
    /// <typeparam name="TSaveData"></typeparam>
    public interface ISlotComponent<TSaveData> : ISlotComponent
        where TSaveData : GameSaveData
    {
        /// <summary>
        /// The component does its work based off of this.
        /// </summary>
        new TSaveData SaveData { get; set; }
    }


}