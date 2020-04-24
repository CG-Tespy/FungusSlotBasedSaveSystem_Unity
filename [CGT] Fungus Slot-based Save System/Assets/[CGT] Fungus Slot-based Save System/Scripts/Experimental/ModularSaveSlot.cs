using System.Collections.Generic;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public class ModularSaveSlot : SlotComponent
    {
        public virtual List<ISlotComponent> Subcomponents { get; protected set; }
        = new List<ISlotComponent>();

        public override void Refresh()
        {
            PassSaveDataToSubcomponents();
        }

        void PassSaveDataToSubcomponents()
        {
            // The idea is to let the subcomponents decide what to do with the
            // data upon being given it
            for (int i = 0; i < Subcomponents.Count; i++)
            {
                var subcomponent = Subcomponents[i];
                subcomponent.SaveData = this.SaveData;
            }
        }

        /// <summary>
        /// Tells you whether this is the first, second, two hundredth, etc slot.
        /// </summary>
        public virtual int Number { get; set; }

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
        
    }

}