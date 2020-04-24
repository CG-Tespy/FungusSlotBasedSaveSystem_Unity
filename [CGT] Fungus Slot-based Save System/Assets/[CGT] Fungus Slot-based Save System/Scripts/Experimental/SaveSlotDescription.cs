using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGTUnity.Fungus.SaveSystem.Experimental
{
    /// <summary>
    /// Base class for save slot components displaying mainly the description.
    /// </summary>
    public abstract class SaveSlotDescription<TTextField> : SlotText<TTextField>, 
        ISlotDescription
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

    /// <summary>
    /// For save slot components that display the description.
    /// </summary>
    public interface ISlotDescription : ISlotComponent
    {
        string Description { get; }
    }
}