using UnityEngine;

namespace CGT.Unity.Fungus.SBSaveSys
{
    /// <summary>
    /// Base class for save slot components displaying mainly the slot number.
    /// </summary>
    public abstract class SaveSlotNumber<TTextField> : SlotText, ISlotNumberDisplayer,
        IPrefixHandler, IPostfixHandler
        where TTextField : class
    {
        [Tooltip("The text displayed right before the number.")]
        [SerializeField] protected string prefix = "Save #";
        [Tooltip("The text displayed right after the number.")]
        [SerializeField] protected string postfix;

        public string Prefix
        { 
            get { return prefix; } 
            set
            {
                if (value == null)
                    prefix = "";
                else
                    prefix = value;
            }
        }
        public string Postfix 
        { 
            get { return postfix; } 
            set
            {
                if (value == null)
                    postfix = "";
                else
                    postfix = value;
            }
        }
        public int SlotNumber { get; protected set; }

        public new TTextField TextField
        {
            get { return base.TextField; }
            set { base.TextField = value; }
        }

        protected virtual void Awake()
        {
            TextField = GetComponent<TTextField>();
        }

        public override void UpdateText()
        {
            UpdateSlotNumber();
            string toDisplay = prefix + SlotNumber + postfix;
            base.TextField.text = toDisplay;
        }

        protected virtual void UpdateSlotNumber()
        {
            if (SaveData == GameSaveData.Null)
            {
                // Null save datas don't have valid slot numbers
                var slotController = GetComponentInParent<SaveSlot>();
                SlotNumber = slotController.transform.GetSiblingIndex();
            }
            else
                SlotNumber = SaveData.SlotNumber;
        }

    }

}