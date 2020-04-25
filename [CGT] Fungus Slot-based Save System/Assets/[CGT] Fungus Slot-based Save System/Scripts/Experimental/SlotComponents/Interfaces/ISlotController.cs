using System.Collections.Generic;

namespace CGT.Unity.Fungus.SBSaveSys
{
    public interface ISlotController : ISlotComponent
    {
        int Number { get; set; }
        IList<ISlotComponent> Subcomponents { get; }
    }
}
