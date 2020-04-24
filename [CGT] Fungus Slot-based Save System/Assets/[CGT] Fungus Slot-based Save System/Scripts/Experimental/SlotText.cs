using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Base class for Save Slot Components that apply their functionality to a 
    /// Unity UI Text component.
    /// </summary>
    public abstract class SlotText : SaveSlotComponent<Text>
    {

        public override GameSaveData SaveData
        {
            get { return base.SaveData; }
            set
            {
                base.SaveData = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Alias for the TextField.
        /// </summary>
        public override Text PartnerComponent
        {
            get { return this.TextField; }
            protected set { this.TextField = value; }
        }

        public Text TextField { get; protected set; }

        protected virtual void Awake()
        {
            TextField = GetComponent<Text>();
        }

        protected abstract void UpdateText();
    }
}