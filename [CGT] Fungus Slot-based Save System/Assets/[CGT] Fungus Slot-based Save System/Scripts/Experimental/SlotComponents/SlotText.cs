using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Base class for Save Slot Components that apply their functionality to a 
    /// Unity UI Text component.
    /// </summary>
    public abstract class SlotText : SlotComponent, ISlotText
    {
        public virtual dynamic TextField { get; set; }

        public override void Refresh()
        {
            UpdateText();
        }

        public abstract void UpdateText();
    }


    public abstract class SlotText<TTextField> : SlotText, ISlotText<TTextField>
        where TTextField: class
    {
        public new TTextField TextField
        {
            get { return base.TextField; }
            set { base.TextField = value; }
        }

        protected virtual void Awake()
        {
            TextField = GetComponent<TTextField>();
        }

    }

    /// <summary>
    /// For save slot components that display text.
    /// </summary>
    public interface ISlotText : ISlotComponent
    {
        dynamic TextField { get; }
        void UpdateText();
    }

    public interface ISlotText<T> : ISlotText
    {
        new T TextField { get; }
    }
}