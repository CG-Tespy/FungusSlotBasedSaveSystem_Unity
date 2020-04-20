using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    public abstract class SaveSlotText : SaveSlotComponent
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

        public Text TextField { get; protected set; }

        protected virtual void Awake()
        {
            TextField = GetComponent<Text>();
        }

        protected abstract void UpdateText();
    }
}