using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// For save slot components that display the description.
    /// </summary>
    public interface ISlotDescriptionDisplayer : ISlotComponent
    {
        string Description { get; }
    }
}
