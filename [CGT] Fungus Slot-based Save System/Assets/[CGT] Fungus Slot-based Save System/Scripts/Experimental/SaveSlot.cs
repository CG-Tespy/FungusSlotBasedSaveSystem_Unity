using System.Collections.Generic;

namespace CGT.Unity.Fungus.SBSaveSys
{
    public class SaveSlot : SlotComponent, ISlotController
    {
        /// <summary>
        /// Tells you whether this is the first, second, two hundredth, etc slot.
        /// </summary>
        public virtual int Number { get; set; }

        public virtual IList<ISlotComponent> Subcomponents { get; protected set; }
        = new List<ISlotComponent>();

        protected virtual void Awake()
        {
            FetchSubcomponents();
        }

        protected virtual void FetchSubcomponents()
        {
            var subcomponentArr = GetComponentsInChildren<ISlotComponent>();
            Subcomponents.AddRange(subcomponentArr);
            // GetComponentsInChildren also gets components from the calling MB's
            // GameObject, for some reason
            Subcomponents.Remove(this);
        }

        protected virtual void Start()
        {
            Refresh();
        }

        public override void Refresh()
        {
            // To keep the subcomponents on the same page as this one
            PassSaveDataToSubcomponents();
        }

        void PassSaveDataToSubcomponents()
        {
            for (int i = 0; i < Subcomponents.Count; i++)
            {
                var subcomponent = Subcomponents[i];
                subcomponent.SaveData = this.SaveData;
            }
        }

    }

    
}