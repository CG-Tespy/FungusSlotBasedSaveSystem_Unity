using System;

namespace CGT.Unity.Fungus.SBSaveSys
{
    public interface ISlotDateDisplayer : ISlotComponent
    {
        DateTime Date { get; }
    }
}
