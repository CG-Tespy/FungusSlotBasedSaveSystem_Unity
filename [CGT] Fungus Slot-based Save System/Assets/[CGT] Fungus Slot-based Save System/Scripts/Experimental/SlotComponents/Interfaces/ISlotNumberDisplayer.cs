namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// For save slot components that display slot numbers.
    /// </summary>
    public interface ISlotNumberDisplayer : ISlotComponent
    {
        int SlotNumber { get; }
    }
}
