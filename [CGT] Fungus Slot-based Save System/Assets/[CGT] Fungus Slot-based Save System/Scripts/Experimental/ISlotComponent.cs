using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public interface ISlotComponent
    {
        GameSaveData SaveData { get; set; }
        void Refresh();
    }


}