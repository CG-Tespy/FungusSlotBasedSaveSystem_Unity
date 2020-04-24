using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMProText = TMPro.TextMeshProUGUI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Base class for Save Slot Components that apply their functionality to a 
    /// TextMeshProUGUI component.
    /// </summary>
    public abstract class SaveSlotTMProUGUI : SaveSlotComponent<TMProText>
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

        public override TMProText PartnerComponent
        {
            get { return this.TextField; }
            protected set { this.TextField = value; }
        }

        /// <summary>
        /// Alias for the PartnerComponent.
        /// </summary>
        public virtual TMProText TextField { get; protected set; }

        protected virtual void Awake()
        {
            TextField = GetComponent<TMProText>();
        }

        protected abstract void UpdateText();
    }
}