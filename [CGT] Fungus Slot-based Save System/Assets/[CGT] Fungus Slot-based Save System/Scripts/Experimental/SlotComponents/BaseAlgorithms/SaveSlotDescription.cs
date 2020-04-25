using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Base class for save slot components displaying mainly the description.
    /// </summary>
    public abstract class SaveSlotDescription<TTextField> : SlotText<TTextField>, 
        ISlotDescriptionDisplayer
        where TTextField: class
    {
        public virtual string Description { get; set; }

        public override void UpdateText()
        {
            Description = SaveData.Description;

            dynamic baseTextField = (dynamic)TextField;
            baseTextField.text = Description;
        }
    }

    
}