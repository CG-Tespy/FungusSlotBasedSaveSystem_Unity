using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public interface ISaveDataChangedListener<TSaveData> where TSaveData: SaveData
    {
        void OnSaveDataChanged(TSaveData oldData, TSaveData newData);
    }

    public interface IGameSaveDataChangedListener : ISaveDataChangedListener<GameSaveData>
    {

    }
}
